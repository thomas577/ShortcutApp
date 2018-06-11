using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShortcutCarousel.Services.Tests
{
    [TestClass]
    public class ConfigurationProviderTests
    {
        [TestMethod]
        public void SaveCarouselConfiguration_Data_Saved()
        {
            IUserXmlConfigurationPath xmlPath = new XmlPathMock();
            ICarouselConfigurationDataMapper mapper = new CarouselConfigurationDataMapper(xmlPath, typeof(CarouselConfiguration));
            CarouselConfiguration config = new CarouselConfiguration();
            config.WindowWidth = 100;
            IConfigurationProvider provider = new ConfigurationProvider(mapper);

            provider.SaveCarouselConfiguration(config);
            ICarouselConfiguration configLoaded = provider.GetCarouselConfiguration();

            Assert.AreEqual(config.WindowWidth, configLoaded.WindowWidth);
        }

        class XmlPathMock : IUserXmlConfigurationPath
        {
            public string UserXmlConfigurationPath
            {
                get
                {
                    return @"\\tgptrading.glb.corp.local\Global\Users\UK\TDier\Documents\ShortcutCarousel.config.xml";
                }
            }
        }
    }
}
