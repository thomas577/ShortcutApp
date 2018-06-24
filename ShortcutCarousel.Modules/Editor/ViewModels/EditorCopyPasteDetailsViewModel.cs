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
	[Export(typeof(IEditorCopyPasteDetailsViewModel))]
	public class EditorCopyPasteDetailsViewModel : NotificationObject, IEditorCopyPasteDetailsViewModel
	{
		private IEventAggregator eventAggregator;

		[ImportingConstructor]
		public EditorCopyPasteDetailsViewModel(IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
			this.eventAggregator.GetEvent<CopyPasteItemSelectedInGridEvent>().Subscribe(
				(ICarouselCopyPasteItem c) => {
					this.CarouselCopyPasteItem = c;
				});
		}

		#region CarouselCopyPasteItem
		private ICarouselCopyPasteItem carouselCopyPasteItem;
		public ICarouselCopyPasteItem CarouselCopyPasteItem
		{
			get
			{
				return this.carouselCopyPasteItem;
			}
			set
			{
				if (this.carouselCopyPasteItem != value)
				{
					if (this.carouselCopyPasteItem != null)
					{
						this.carouselCopyPasteItem.PropertyChanged -= this.CarouselCopyPasteItem_PropertyChanged;
					}
					this.carouselCopyPasteItem = value;
					if (this.carouselCopyPasteItem != null)
					{
						this.carouselCopyPasteItem.PropertyChanged += this.CarouselCopyPasteItem_PropertyChanged;
					}
					this.RaisePropertyChanged(string.Empty);
				}
			}
		}

		private void CarouselCopyPasteItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.RaisePropertyChanged(e.PropertyName);
		}
		#endregion

		public Color ColorBackground
		{
			get
			{
				return this.CarouselCopyPasteItem?.ColorBackground ?? Colors.Black;
			}
		}

		public double ColorHue
		{
			get
			{
				return this.CarouselCopyPasteItem?.ColorHue ?? 0.0;
			}
			set
			{
				if (this.CarouselCopyPasteItem != null)
				{
					this.CarouselCopyPasteItem.ColorHue = value;
				}
			}
		}

		public double ColorLuminosity
		{
			get
			{
				return this.CarouselCopyPasteItem?.ColorLuminosity ?? 0.0;
			}
			set
			{
				if (this.CarouselCopyPasteItem != null)
				{
					this.CarouselCopyPasteItem.ColorLuminosity = value;
				}
			}
		}

		public ColorType ColorType
		{
			get
			{
				return this.CarouselCopyPasteItem?.ColorType ?? ColorType.Grayscale;
			}
			set
			{
				if (this.CarouselCopyPasteItem != null)
				{
					this.CarouselCopyPasteItem.ColorType = value;
				}
			}
		}

		public string DisplayName
		{
			get
			{
				return this.CarouselCopyPasteItem?.DisplayName ?? string.Empty;
			}
			set
			{
				if (this.CarouselCopyPasteItem != null)
				{
					this.CarouselCopyPasteItem.DisplayName = value;
				}
			}
		}

		public string Content
		{
			get
			{
				return this.CarouselCopyPasteItem?.Content ?? string.Empty;
			}
			set
			{
				if (this.CarouselCopyPasteItem != null)
				{
					this.CarouselCopyPasteItem.Content = value;
				}
			}
		}
	}
}
