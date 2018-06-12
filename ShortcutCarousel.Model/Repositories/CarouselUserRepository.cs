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
                CarouselUserDTO userDTO = (CarouselUserDTO)serializer.ReadObject(fs);
                CarouselUser user = new CarouselUser();
                user.Name = userDTO.Name;
                foreach (CarouselCopyPasteItemDTO carouselCopyPasteItemDTO in userDTO.CopyPasteItems)
                {
                    CarouselCopyPasteItem carouselCopyPasteItem = new CarouselCopyPasteItem(this.clipboardService, this.carouselColorSettings);
                    carouselCopyPasteItem.Content = carouselCopyPasteItemDTO.Content;
                    carouselCopyPasteItem.DisplayName = carouselCopyPasteItemDTO.DisplayName;
                    carouselCopyPasteItem.DisplayOrder = carouselCopyPasteItemDTO.DisplayOrder;
                    carouselCopyPasteItem.ColorType = carouselCopyPasteItemDTO.ColorType;
                    carouselCopyPasteItem.ColorHue = carouselCopyPasteItemDTO.ColorHue;
                    carouselCopyPasteItem.ColorLuminosity = carouselCopyPasteItemDTO.ColorLuminosity;
                    user.CopyPasteItems.Add(carouselCopyPasteItem);
                }
                foreach (CarouselFileDropItemDTO carouselFileDropItemDTO in userDTO.FileDropItems)
                {
                    CarouselFileDropItem carouselFileDropItem = new CarouselFileDropItem(this.carouselColorSettings);
                    carouselFileDropItem.DropProcessorName = carouselFileDropItemDTO.DropProcessorName;
                    carouselFileDropItem.DisplayName = carouselFileDropItemDTO.DisplayName;
                    carouselFileDropItem.DisplayOrder = carouselFileDropItemDTO.DisplayOrder;
                    carouselFileDropItem.ColorType = carouselFileDropItemDTO.ColorType;
                    carouselFileDropItem.ColorHue = carouselFileDropItemDTO.ColorHue;
                    carouselFileDropItem.ColorLuminosity = carouselFileDropItemDTO.ColorLuminosity;
                    user.FileDropItems.Add(carouselFileDropItem);
                }
                return user;
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
