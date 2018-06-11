using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Services
{
    [Export(typeof(IConfigurationProvider))]
    public class ConfigurationProvider : IConfigurationProvider
    {
        private ICarouselConfigurationDataMapper carouselConfigurationDataMapper;
        private ICarouselConfiguration carouselConfiguration;

        [ImportingConstructor]
        public ConfigurationProvider(ICarouselConfigurationDataMapper carouselConfigurationDataMapper)
        {
            this.carouselConfigurationDataMapper = carouselConfigurationDataMapper;
        }

        public ICarouselConfiguration GetCarouselConfiguration()
        {
            if (this.carouselConfiguration == null)
            {
                this.carouselConfiguration = this.carouselConfigurationDataMapper.LoadFromXml();
            }
            return this.carouselConfiguration;
        }

        public void SaveCarouselConfiguration(ICarouselConfiguration carouselConfiguration)
        {
            this.carouselConfiguration = carouselConfiguration;
            this.carouselConfigurationDataMapper.Save(carouselConfiguration);
        }
    }
}
