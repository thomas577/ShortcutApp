using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortcutCarousel.Model;
using ShortcutCarousel.Data;
using ShortcutCarousel.Clipboard;
using ShortcutCarousel.Settings;
using System.IO;

namespace ShortcutCarousel.Data.Tests
{
    [TestClass]
    public class DataServiceTests
    {
        [TestMethod]
        public void SaveUser_thomas_Success()
        {
            IClipboardService clip = new ClipboardServiceMock();
            ICarouselColorSettings colorSettings = new CarouselColorSettingsMock();
            CarouselUser thomas = new CarouselUser();
            thomas.Name = "thomas";
            thomas.CopyPasteItems.Add(new CarouselCopyPasteItem(clip, colorSettings)
            {
                Content = "content 1 for thomas",
                DisplayName = "content 1"
            });
            ICarouselUsersSavePath savePath = new CarouselUsersSavePathMock();
            ICarouselUserRepository repo = new CarouselUserRepository(savePath, clip, colorSettings);
            DataService dataService = new DataService(repo);

            dataService.SaveUser(thomas);

            Assert.IsTrue(File.Exists(Path.Combine(savePath.CarouselUsersSavePath, "thomas.xml")));
        }

        [TestMethod]
        public void LoadUserByName_thomas_Success()
        {
            IClipboardService clip = new ClipboardServiceMock();
            ICarouselColorSettings colorSettings = new CarouselColorSettingsMock();
            CarouselUser antoine = new CarouselUser();
            antoine.Name = "antoine";
            antoine.CopyPasteItems.Add(new CarouselCopyPasteItem(clip, colorSettings)
            {
                Content = "content 1 for antoine",
                DisplayName = "content 1"
            });
            ICarouselUsersSavePath savePath = new CarouselUsersSavePathMock();
            ICarouselUserRepository repo = new CarouselUserRepository(savePath, clip, colorSettings);
            DataService dataService = new DataService(repo);

            dataService.SaveUser(antoine);
            ICarouselUser loadedUser = dataService.LoadUserByName("antoine");

            Assert.AreEqual(loadedUser.Name, "antoine");
        }
    }

    class ClipboardServiceMock : IClipboardService
    {
        public void CopyToClipboard(string copiedContent)
        {
            
        }
    }

    class CarouselColorSettingsMock : ICarouselColorSettings
    {
        public double DefaultLuminosity
        {
            get
            {
                return 0.5;
            }
        }
    }

    class CarouselUsersSavePathMock : ICarouselUsersSavePath
    {
        public string CarouselUsersSavePath
        {
            get
            {
                return @"C:\temp";
            }
        }
    }
}
