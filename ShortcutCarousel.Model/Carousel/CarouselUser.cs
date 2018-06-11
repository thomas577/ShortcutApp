using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Microsoft.Practices.Prism.ViewModel;

namespace ShortcutCarousel.Model
{
	[DataContract]
	public class CarouselUser : NotificationObject, ICarouselUser
	{
		public CarouselUser()
		{
			this.copyPasteItems = new ObservableCollection<ICarouselItem>();
			this.fileDropItems = new ObservableCollection<ICarouselItem>();
		}

		private readonly IList<ICarouselItem> copyPasteItems;
		private readonly IList<ICarouselItem> fileDropItems;

		[DataMember]
		public IList<ICarouselItem> CopyPasteItems
		{
			get
			{
				return this.copyPasteItems;
			}
		}

		[DataMember]
		public IList<ICarouselItem> FileDropItems
		{
			get
			{
				return this.fileDropItems;
			}
		}

		private string name;
		[DataMember]
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				if (this.name != value)
				{
					this.name = value;
					this.RaisePropertyChanged(() => this.Name);
				}
			}
		}
	}
}
