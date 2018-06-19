using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortcutCarousel.Model;
using ShortcutCarousel.Data;
using ShortcutCarousel.Clipboard;
using ShortcutCarousel.Settings;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
            ICarouselUsersSavePath savePath = new CarouselUsersSavePathMock();
            ICarouselUserRepository repo = new CarouselUserRepository(savePath, clip, colorSettings);
            DataService dataService = new DataService(repo);
            CarouselUser thomas = new CarouselUser();
            thomas.Name = "thomas";
            thomas.CopyPasteItems.Add(new CarouselCopyPasteItem(clip, colorSettings)
            {
                Content = "content 1 for thomas",
                DisplayName = "content 1"
            });
            
            dataService.SaveUser(thomas);

            Assert.IsTrue(File.Exists(Path.Combine(savePath.CarouselUsersSavePath, "thomas.xml")));
        }

        [TestMethod]
        public void LoadUserByName_antoine_Success()
        {
            IClipboardService clip = new ClipboardServiceMock();
            ICarouselColorSettings colorSettings = new CarouselColorSettingsMock();
            ICarouselUsersSavePath savePath = new CarouselUsersSavePathMock();
            ICarouselUserRepository repo = new CarouselUserRepository(savePath, clip, colorSettings);
            DataService dataService = new DataService(repo);
            CarouselUser antoine = new CarouselUser();
            antoine.Name = "antoine";
            antoine.CopyPasteItems.Add(new CarouselCopyPasteItem(clip, colorSettings)
            {
                Content = "content 1 for antoine",
                DisplayName = "content 1"
            });

            dataService.SaveUser(antoine);
            ICarouselUser loadedUser = dataService.LoadUserByName("antoine");

            Assert.AreEqual(loadedUser.Name, "antoine");
        }

        [TestMethod]
        public void GetAllUserNames_NonEmpty_TwoElements()
        {
            IClipboardService clip = new ClipboardServiceMock();
            ICarouselColorSettings colorSettings = new CarouselColorSettingsMock();
            ICarouselUsersSavePath savePath = new CarouselUsersSavePathMock();
            ICarouselUserRepository repo = new CarouselUserRepository(savePath, clip, colorSettings);
            DataService dataService = new DataService(repo);

            CarouselUser thomas = new CarouselUser();
            thomas.Name = "thomas";
            thomas.FileDropItems.Add(new CarouselFileDropItem(colorSettings)
            {
                DropProcessorName = "processor 1 for thomas",
                DisplayName = "content 1"
            });
            thomas.CopyPasteItems.Add(new CarouselCopyPasteItem(clip, colorSettings)
            {
                Content = "content 1 for thomas",
                DisplayName = "content 1"
            });

            CarouselUser antoine = new CarouselUser();
            antoine.Name = "antoine";
            antoine.CopyPasteItems.Add(new CarouselCopyPasteItem(clip, colorSettings)
            {
                Content = "content 1 for antoine",
                DisplayName = "content 1"
            });

            dataService.SaveUser(thomas);
            dataService.SaveUser(antoine);

            IList<string> allUserNames = dataService.GetAllUserNames();

            CollectionAssert.Contains(allUserNames.ToList(), "thomas");
            CollectionAssert.Contains(allUserNames.ToList(), "antoine");
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
