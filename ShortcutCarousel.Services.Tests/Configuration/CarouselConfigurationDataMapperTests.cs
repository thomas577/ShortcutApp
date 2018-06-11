using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortcutCarousel.Services;
using System.IO;

namespace ShortcutCarousel.Services.Tests
{
    /// <summary>
    /// Summary description for CarouselConfigurationDataMapper
    /// </summary>
    [TestClass]
    public class CarouselConfigurationDataMapperTests
    {
        [TestMethod]
        public void Save_Data_CreatesXmlFile()
        {
            IUserXmlConfigurationPath xmlPath = new XmlPathMock();
            ICarouselConfigurationDataMapper mapper = new CarouselConfigurationDataMapper(xmlPath, typeof(CarouselConfiguration));
            CarouselConfiguration config = new CarouselConfiguration();
            config.WindowWidth = 500;

            mapper.Save(config);

            Assert.IsTrue(File.Exists(xmlPath.UserXmlConfigurationPath));
        }

        [TestMethod]
        public void LoadFromXml_Data_SameObjects()
        {
            IUserXmlConfigurationPath xmlPath = new XmlPathMock();
            ICarouselConfigurationDataMapper mapper = new CarouselConfigurationDataMapper(xmlPath, typeof(CarouselConfiguration));
            CarouselConfiguration config = new CarouselConfiguration();
            config.WindowWidth = 100;

            mapper.Save(config);
            ICarouselConfiguration configLoaded = mapper.LoadFromXml();

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
