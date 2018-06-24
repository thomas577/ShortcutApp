using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.ViewModel;
using ShortcutCarousel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ShortcutCarousel.Events;

namespace ShortcutCarousel.Modules.Editor
{
	[Export(typeof(IEditorFileDropDetailsViewModel))]
	public class EditorFileDropDetailsViewModel : NotificationObject, IEditorFileDropDetailsViewModel
	{
		private IEventAggregator eventAggregator;

		[ImportingConstructor]
		public EditorFileDropDetailsViewModel(IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
			this.eventAggregator.GetEvent<FileDropItemSelectedInGridEvent>().Subscribe(
				(ICarouselFileDropItem c) => { this.CarouselFileDropItem = c; });
		}

		#region CarouselFileDropItem
		private ICarouselFileDropItem carouselFileDropItem;
		public ICarouselFileDropItem CarouselFileDropItem
		{
			get
			{
				return this.carouselFileDropItem;
			}
			set
			{
				if (this.carouselFileDropItem != value)
				{
					this.carouselFileDropItem.PropertyChanged -= this.CarouselFileDropItem_PropertyChanged;
					this.carouselFileDropItem = value;
					this.carouselFileDropItem.PropertyChanged += this.CarouselFileDropItem_PropertyChanged;
					this.RaisePropertyChanged(string.Empty);
				}
			}
		}

		private void CarouselFileDropItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.RaisePropertyChanged(e.PropertyName);
		}
		#endregion

		public Color ColorBackground
		{
			get
			{
				return this.CarouselFileDropItem.ColorBackground;
			}
		}

		public double ColorHue
		{
			get
			{
				return this.CarouselFileDropItem.ColorHue;
			}
			set
			{
				this.CarouselFileDropItem.ColorHue = value;
			}
		}

		public double ColorLuminosity
		{
			get
			{
				return this.CarouselFileDropItem.ColorLuminosity;
			}
			set
			{
				this.CarouselFileDropItem.ColorLuminosity = value;
			}
		}

		public ColorType ColorType
		{
			get
			{
				return this.CarouselFileDropItem.ColorType;
			}
			set
			{
				this.CarouselFileDropItem.ColorType = value;
			}
		}

		public string DisplayName
		{
			get
			{
				return this.CarouselFileDropItem.DisplayName;
			}
			set
			{
				this.CarouselFileDropItem.DisplayName = value;
			}
		}

		public string DropProcessorName
		{
			get
			{
				return this.CarouselFileDropItem.DropProcessorName;
			}
			set
			{
				this.CarouselFileDropItem.DropProcessorName = value;
			}
		}
	}
}
