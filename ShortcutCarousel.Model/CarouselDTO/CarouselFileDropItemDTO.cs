using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ShortcutCarousel.Model
{
    [DataContract]
    public class CarouselFileDropItemDTO
    {
		public CarouselFileDropItemDTO()
		{

		}

		public CarouselFileDropItemDTO(ICarouselFileDropItem carouselFileDropItem)
		{
			this.DropProcessorName = carouselFileDropItem.DropProcessorName;
			this.DisplayName = carouselFileDropItem.DisplayName;
			this.DisplayOrder = carouselFileDropItem.DisplayOrder;
			this.ColorType = carouselFileDropItem.ColorType;
			this.ColorHue = carouselFileDropItem.ColorHue;
			this.ColorLuminosity = carouselFileDropItem.ColorLuminosity;
		}

        [DataMember]
        public string DropProcessorName { get; set; }

        public bool AcceptsDrops { get; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public int DisplayOrder { get; set; }

        public Color ColorBackground { get; set; }
        [DataMember]
        public ColorType ColorType { get; set; }
        [DataMember]
        public double ColorHue { get; set; }
        [DataMember]
        public double ColorLuminosity { get; set; }

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
