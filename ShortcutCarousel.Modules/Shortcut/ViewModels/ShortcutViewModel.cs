using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.ViewModel;
using ShortcutCarousel.Data;
using ShortcutCarousel.Events;
using ShortcutCarousel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShortcutCarousel.Modules.Shortcut
{
    [Export(typeof(IShortcutViewModel))]
    public class ShortcutViewModel : NotificationObject, IShortcutViewModel
    {
        private IDataService dataService;
        private IEventAggregator eventAggregator;

        [ImportingConstructor]
        public ShortcutViewModel(IDataService dataService, IEventAggregator eventAggregator)
        {
            this.dataService = dataService;
            this.eventAggregator = eventAggregator;
            this.CarouselUser = this.dataService.LoadUserByName("sampleuser");

            // Register to the event that signals that we have opened the user editing window
            // and therefore we need to provide the current CarouselUser
            this.eventAggregator.GetEvent<UserEditingStartedEvent>().Subscribe(
                (ICarouselUser c) => 
                {
                    this.eventAggregator.GetEvent<CarouselUserChangedEvent>().Publish(this.CarouselUser);
                });
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
                    this.eventAggregator.GetEvent<CarouselUserChangedEvent>().Publish(this.carouselUser);
                    this.RaisePropertyChanged(() => this.CarouselUser);
                }
            }
        }
		#endregion CarouselUser

		#region EditCommand
		private ICommand editCommand;
		public ICommand EditCommand
		{
			get
			{
				if (this.editCommand == null)
				{
					this.editCommand = new DelegateCommand(this.ExecuteEdit, this.CanExecuteEdit);
				}
				return this.editCommand;
			}
		}

		public void ExecuteEdit()
		{
			this.eventAggregator.GetEvent<EditUserEvent>().Publish(this.CarouselUser);
		}

		public bool CanExecuteEdit()
		{
			return true;
		}
		#endregion EditCommand
	}
}
