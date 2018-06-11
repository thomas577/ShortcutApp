using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShortcutCarousel.Model
{
	[DataContract]
	public class CarouselUserDTO
	{
		public CarouselUserDTO()
		{
			
		}

		public CarouselUserDTO(ICarouselUser user)
		{
			this.Name = user.Name;

			this.CopyPasteItems = new List<CarouselCopyPasteItemDTO>();
			foreach (ICarouselCopyPasteItem carouselCopyPasteItem in user.CopyPasteItems)
			{
				this.CopyPasteItems.Add(new CarouselCopyPasteItemDTO(carouselCopyPasteItem));
			}

			this.FileDropItems = new List<CarouselFileDropItemDTO>();
			foreach (ICarouselFileDropItem carouselFileDropItem in user.FileDropItems)
			{
				this.FileDropItems.Add(new CarouselFileDropItemDTO(carouselFileDropItem));
			}
		}

		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public IList<CarouselCopyPasteItemDTO> CopyPasteItems { get; set; }
		[DataMember]
		public IList<CarouselFileDropItemDTO> FileDropItems { get; set; }
	}
}
