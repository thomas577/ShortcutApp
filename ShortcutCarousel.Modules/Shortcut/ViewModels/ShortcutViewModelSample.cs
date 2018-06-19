using ShortcutCarousel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace ShortcutCarousel.Modules.Shortcut
{
    public class ShortcutViewModelSample : IShortcutViewModel
    {
        public ShortcutViewModelSample()
        {

        }

        public ICarouselUser CarouselUser
        {
            get
            {
                CarouselUser user = new CarouselUser();
                user.Name = "FakeName";
                user.FileDropItems.Add(new CarouselFileDropItemSample()
                {
                    DisplayName = "File Drop 1",
                    DisplayOrder = 0,
                    DropProcessorName = "DropProcessor1"
                });
                user.FileDropItems.Add(new CarouselFileDropItemSample()
                {
                    DisplayName = "File Drop 2",
                    DisplayOrder = 1,
                    DropProcessorName = "DropProcessor2"
                });
				user.CopyPasteItems.Add(new CarouselCopyPasteItemSample()
				{
					DisplayName = "Copy paste 1",
					DisplayOrder = 0,
					Content = "Copy me! 1"
				});
				user.CopyPasteItems.Add(new CarouselCopyPasteItemSample()
				{
					DisplayName = "Copy paste 2",
					DisplayOrder = 1,
					Content = "Copy me! 2"
				});
				user.CopyPasteItems.Add(new CarouselCopyPasteItemSample()
				{
					DisplayName = "Copy paste 3",
					DisplayOrder = 2,
					Content = "Copy me! 3"
				});
				return user;
            }
            set
            {

            }
        }

		public ICommand EditCommand
		{
			get
			{
				return null;
			}
		}
	}

    internal class CarouselFileDropItemSample : ICarouselFileDropItem
    {
        public bool AcceptsDrops
        {
            get
            {
                return true;
            }
        }

        public Color ColorBackground
        {
            get
            {
                return Colors.Aqua;
            }
        }

        public double ColorHue
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double ColorLuminosity
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ColorType ColorType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string DisplayName
        {
            get;
            set;
        }

        public int DisplayOrder
        {
            get;
            set;
        }

        public string DropProcessorName
        {
            get;
            set;
        }

        public void Clicked()
        {
            throw new NotImplementedException();
        }

        public void ReceiveDrop(IEnumerable<string> paths)
        {
            throw new NotImplementedException();
        }
    }

	internal class CarouselCopyPasteItemSample : ICarouselCopyPasteItem
	{
		public bool AcceptsDrops
		{
			get
			{
				return false;
			}
		}

		public Color ColorBackground
		{
			get
			{
				return Colors.Beige;
			}
		}

		public double ColorHue
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public double ColorLuminosity
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ColorType ColorType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public string Content
		{
			get;
			set;
		}

		public string DisplayName
		{
			get;
			set;
		}

		public int DisplayOrder
		{
			get;
			set;
		}

		public void Clicked()
		{
			throw new NotImplementedException();
		}

		public void ReceiveDrop(IEnumerable<string> paths)
		{
			throw new NotImplementedException();
		}
	}
}
