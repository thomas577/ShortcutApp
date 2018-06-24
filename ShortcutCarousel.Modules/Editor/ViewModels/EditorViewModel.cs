using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.ViewModel;
using ShortcutCarousel.Events;
using ShortcutCarousel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Modules.Editor
{
    [Export(typeof(IEditorViewModel))]
    public class EditorViewModel : NotificationObject, IEditorViewModel
    {
        private IEventAggregator eventAggregator;

        [ImportingConstructor]
        public EditorViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<CarouselUserChangedEvent>().Subscribe(this.CarouselUserChanged);
            this.eventAggregator.GetEvent<UserEditingStartedEvent>().Publish(null);
        }

        #region CarouselUser
        private ICarouselUser carouselUser;
        public ICarouselUser CarouselUser
        {
            get
            {
                return this.carouselUser;
            }
            set
            {
                if (this.carouselUser != value)
                {
                    this.carouselUser = value;
                    this.RaisePropertyChanged(() => this.CarouselUser);
                }
            }
        }
		#endregion CarouselUser

		private ICarouselCopyPasteItem copyPasteItemSelected;
		public ICarouselCopyPasteItem CopyPasteItemSelected
		{
			get
			{
				return this.copyPasteItemSelected;
			}
			set
			{
				if (this.copyPasteItemSelected != value)
				{
					this.copyPasteItemSelected = value;
					this.eventAggregator.GetEvent<CopyPasteItemSelectedInGridEvent>().Publish(this.copyPasteItemSelected);
					this.RaisePropertyChanged(() => this.CopyPasteItemSelected);
				}
			}
		}

		private ICarouselFileDropItem fileDropItemSelected;
		public ICarouselFileDropItem FileDropItemSelected
		{
			get
			{
				return this.fileDropItemSelected;
			}
			set
			{
				if (this.fileDropItemSelected != value)
				{
					this.fileDropItemSelected = value;
					this.eventAggregator.GetEvent<FileDropItemSelectedInGridEvent>().Publish(this.fileDropItemSelected);
					this.RaisePropertyChanged(() => this.FileDropItemSelected);
				}
			}
		}

		private void CarouselUserChanged(ICarouselUser carouselUser)
        {
            if (this.CarouselUser == null)
            {
                this.CarouselUser = carouselUser;
            }
            else if (carouselUser != this.CarouselUser)
            {
                // Show message to save and start editing another user?
            }
        }
    }
}
