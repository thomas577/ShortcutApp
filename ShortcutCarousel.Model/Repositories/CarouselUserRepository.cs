using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortcutCarousel.Settings;
using ShortcutCarousel.Clipboard;
using System.ComponentModel.Composition;
using System.IO;
using System.Runtime.Serialization;

namespace ShortcutCarousel.Model
{
    [Export(typeof(ICarouselUserRepository))]
    public class CarouselUserRepository : ICarouselUserRepository
    {
        private ICarouselUsersSavePath carouselUsersSavePath;
        private IClipboardService clipboardService;
        private ICarouselColorSettings carouselColorSettings;

		[ImportingConstructor]
        public CarouselUserRepository(ICarouselUsersSavePath carouselUsersSavePath, IClipboardService clipboardService, ICarouselColorSettings carouselColorSettings)
        {
            this.carouselUsersSavePath = carouselUsersSavePath;
			this.clipboardService = clipboardService;
			this.carouselColorSettings = carouselColorSettings;
		}

        public IList<ICarouselUser> GetAll()
        {
            IList<ICarouselUser> users = new List<ICarouselUser>();
            string path = this.GetActualSavePath();
            if (Directory.Exists(path))
            {
                foreach (string candidatePath in Directory.GetFiles(path))
                {
                    try
                    {
                        ICarouselUser user = this.LoadFromPath(candidatePath);
                        if (user != null)
                        {
                            users.Add(user);
                        }
                    }
                    catch (Exception)
                    {
                        // ignore
                    }
                }
                return users;
            }
            else
            {
                throw new DirectoryNotFoundException("Unable to find the user file directory.");
            }
        }

        public IList<string> GetAllNames()
        {
            return this.GetAll().Select(c => c.Name).ToList();
        }

        public ICarouselUser GetByName(string name)
        {
            string path = CarouselUserRepository.ConstructPath(this.GetActualSavePath(), name);
            if (File.Exists(path))
            {
                return this.LoadFromPath(path);
            }
            else
            {
                throw new FileNotFoundException("Unable to find the user file.", path);
            }
        }

        public void Save(ICarouselUser user)
        {
            string path = CarouselUserRepository.ConstructPath(this.GetActualSavePath(), user.Name);
            DataContractSerializer serializer = new DataContractSerializer(typeof(CarouselUserDTO));
            // Creates or overwrites the file at the path given.
            using (FileStream fs = File.Open(path, FileMode.Create))
            {
                serializer.WriteObject(fs, new CarouselUserDTO(user));
            }
        }

        private ICarouselUser LoadFromPath(string path)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(CarouselUserDTO));
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                return new CarouselUser((CarouselUserDTO)serializer.ReadObject(fs), this.clipboardService, this.carouselColorSettings);
            }
        }

        private string GetActualSavePath()
        {
            if (this.carouselUsersSavePath == null || string.IsNullOrWhiteSpace(this.carouselUsersSavePath.CarouselUsersSavePath))
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            }
            return this.carouselUsersSavePath.CarouselUsersSavePath;
        }

        private static string ConstructPath(string baseDirectoryPath, string name)
        {
            return Path.Combine(baseDirectoryPath, string.Format("{0}.xml", name));
        }
    }
}
