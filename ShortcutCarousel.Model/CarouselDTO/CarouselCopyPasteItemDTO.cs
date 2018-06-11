using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows.Media;

namespace ShortcutCarousel.Model
{
    [DataContract]
    public class CarouselCopyPasteItemDTO
    {
		public CarouselCopyPasteItemDTO()
		{
			
		}

		public CarouselCopyPasteItemDTO(ICarouselCopyPasteItem carouselCopyPasteItem)
		{
			this.Content = carouselCopyPasteItem.Content;
			this.DisplayName = carouselCopyPasteItem.DisplayName;
			this.DisplayOrder = carouselCopyPasteItem.DisplayOrder;
			this.ColorType = carouselCopyPasteItem.ColorType;
			this.ColorHue = carouselCopyPasteItem.ColorHue;
			this.ColorLuminosity = carouselCopyPasteItem.ColorLuminosity;
		}

        [DataMember]
        public string Content { get; set; }

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
