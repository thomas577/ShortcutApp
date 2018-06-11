using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;
using System.Windows.Media;
using ShortcutCarousel.Settings;
using System.Runtime.Serialization;

namespace ShortcutCarousel.Model
{
	[DataContract]
    [KnownType(typeof(CarouselCopyPasteItem))]
    [KnownType(typeof(CarouselFileDropItem))]
	public abstract class CarouselItem : NotificationObject, ICarouselItem
	{
		private ICarouselColorSettings carouselColorSettings;

		public CarouselItem(ICarouselColorSettings carouselColorSettings)
		{
			this.carouselColorSettings = carouselColorSettings;
		}

		public abstract void Clicked();
		public abstract void ReceiveDrop(IEnumerable<string> paths);
        
		public abstract bool AcceptsDrops { get; }

		private string displayName;
		[DataMember]
		public string DisplayName
		{
			get
			{
				return this.displayName;
			}
			set
			{
				if (this.displayName != value)
				{
					this.displayName = value;
					this.RaisePropertyChanged(() => this.DisplayName);
				}
			}
		}

		private int displayOrder;
		[DataMember]
		public int DisplayOrder
		{
			get
			{
				return this.displayOrder;
			}
			set
			{
				if (this.displayOrder != value)
				{
					this.displayOrder = value;
					this.RaisePropertyChanged(() => this.DisplayOrder);
				}
			}
		}

		public Color ColorBackground
		{
			get
			{
				switch (this.ColorType)
				{
					case ColorType.Grayscale:
						return ColorHelper.CreateGrayscaleColorFromLuminosity(this.ColorLuminosity);
					case ColorType.Hue:
						return ColorHelper.CreateBackgroundColorFromHue(this.ColorHue);
					default:
						break;
				}
				return ColorHelper.CreateGrayscaleColorFromLuminosity(this.carouselColorSettings.DefaultLuminosity);
			}
		}

		private ColorType colorType;
		[DataMember]
		public ColorType ColorType
		{
			get
			{
				return colorType;
			}
			set
			{
				if (this.colorType != value)
				{
					this.colorType = value;
					this.RaisePropertyChanged(() => this.ColorType);
					this.RaisePropertyChanged(() => this.ColorBackground);
				}
			}
		}

		private double colorHue;
		[DataMember]
		public double ColorHue
		{
			get
			{
				return colorHue;
			}
			set
			{
				if (this.colorHue != value)
				{
					this.colorHue = value;
					this.RaisePropertyChanged(() => this.ColorHue);
					this.RaisePropertyChanged(() => this.ColorBackground);
				}
			}
		}

		private double colorLuminosity;
		[DataMember]
		public double ColorLuminosity
		{
			get
			{
				return colorLuminosity;
			}
			set
			{
				if (this.colorLuminosity != value)
				{
					this.colorLuminosity = value;
					this.RaisePropertyChanged(() => this.ColorLuminosity);
					this.RaisePropertyChanged(() => this.ColorBackground);
				}
			}
		}
	}
}
