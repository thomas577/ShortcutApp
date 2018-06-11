using ShortcutCarousel.Clipboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ShortcutCarousel.Settings;

namespace ShortcutCarousel.Model
{
	[DataContract]
	public class CarouselCopyPasteItem : CarouselItem, ICarouselItem, ICarouselCopyPasteItem
	{
		private IClipboardService clipboardService;

		public CarouselCopyPasteItem(IClipboardService clipboardService, ICarouselColorSettings carouselColorSettings)
			: base(carouselColorSettings)
		{
			this.clipboardService = clipboardService;
		}

		public CarouselCopyPasteItem(CarouselCopyPasteItemDTO carouselCopyPasteItem, IClipboardService clipboardService, ICarouselColorSettings carouselColorSettings)
			: base(carouselColorSettings)
		{
			this.clipboardService = clipboardService;
			this.Content = carouselCopyPasteItem.Content;
			this.DisplayName = carouselCopyPasteItem.DisplayName;
			this.DisplayOrder = carouselCopyPasteItem.DisplayOrder;
			this.ColorType = carouselCopyPasteItem.ColorType;
			this.ColorHue = carouselCopyPasteItem.ColorHue;
			this.ColorLuminosity = carouselCopyPasteItem.ColorLuminosity;
		}

		private string content;
		[DataMember]
		public string Content
		{
			get
			{
				return this.content;
			}
			set
			{
				if (this.content != value)
				{
					this.content = value;
					this.RaisePropertyChanged(() => this.Content);
				}
			}
		}

		public override bool AcceptsDrops
		{
			get
			{
				return false;
			}
		}

		public override void Clicked()
		{
			if (this.Content != null)
			{
				this.clipboardService.CopyToClipboard(this.Content);
			}
		}

		public override void ReceiveDrop(IEnumerable<string> paths)
		{
			throw new NotImplementedException();
		}
	}
}
