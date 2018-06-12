using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Microsoft.Practices.Prism.ViewModel;
using ShortcutCarousel.Settings;
using ShortcutCarousel.Clipboard;

namespace ShortcutCarousel.Model
{
	[DataContract]
	public class CarouselUser : NotificationObject, ICarouselUser
	{
		public CarouselUser()
		{
			this.CopyPasteItems = new ObservableCollection<ICarouselCopyPasteItem>();
			this.FileDropItems = new ObservableCollection<ICarouselFileDropItem>();
		}

        [DataMember]
        public IList<ICarouselCopyPasteItem> CopyPasteItems { get; private set; }

        [DataMember]
        public IList<ICarouselFileDropItem> FileDropItems { get; private set; }
        
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
