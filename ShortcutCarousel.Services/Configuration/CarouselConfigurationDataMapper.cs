using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Services
{
    [Export(typeof(ICarouselConfigurationDataMapper))]
    public class CarouselConfigurationDataMapper : ICarouselConfigurationDataMapper
    {
        private IUserXmlConfigurationPath userXmlConfigurationPath;
        private System.Type type;

        [ImportingConstructor]
        public CarouselConfigurationDataMapper(IUserXmlConfigurationPath userXmlConfigurationPath)
        {
            this.userXmlConfigurationPath = userXmlConfigurationPath;
            this.type = typeof(CarouselConfiguration);
        }

        public CarouselConfigurationDataMapper(IUserXmlConfigurationPath userXmlConfigurationPath, System.Type type)
            : this(userXmlConfigurationPath)
        {
            this.type = type;
        }

        public ICarouselConfiguration LoadFromXml()
        {
            DataContractSerializer serializer = new DataContractSerializer(this.type);
            using (FileStream fs = File.Open(this.userXmlConfigurationPath.UserXmlConfigurationPath, FileMode.Open))
            {
                return (ICarouselConfiguration)serializer.ReadObject(fs);
            }
        }

        public void Save(ICarouselConfiguration carouselConfiguration)
        {
            DataContractSerializer serializer = new DataContractSerializer(this.type);
            // Creates or overwrites the file at the path given.
            using (FileStream fs = File.Open(this.userXmlConfigurationPath.UserXmlConfigurationPath, FileMode.Create))
            {
                serializer.WriteObject(fs, carouselConfiguration);
            }
        }
    }
}
