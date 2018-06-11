using ShortcutCarousel.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShortcutCarousel.Model
{
	[DataContract]
	public class CarouselFileDropItem : CarouselItem, ICarouselItem
	{
		private ICarouselDropProcessor dropProcessor;

		public CarouselFileDropItem(ICarouselColorSettings carouselColorSettings) 
			: base(carouselColorSettings)
		{

		}

		private string dropProcessorName;
		[DataMember]
		public string DropProcessorName
		{
			get
			{
				return this.dropProcessorName;
			}
			set
			{
				if (this.dropProcessorName != value)
				{
					this.dropProcessorName = value;
					this.RaisePropertyChanged(() => this.DropProcessorName);
				}
			}
		}

		public override bool AcceptsDrops
		{
			get
			{
				return true;
			}
		}

		public override void Clicked()
		{
			throw new NotImplementedException();
		}

		public override void ReceiveDrop(IEnumerable<string> paths)
		{
			if (this.dropProcessor != null)
			{
				this.dropProcessor.ProcessDrop(paths);
			}
		}
	}
}
