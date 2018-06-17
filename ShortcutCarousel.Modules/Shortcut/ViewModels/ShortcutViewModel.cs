using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.ViewModel;
using ShortcutCarousel.Data;
using ShortcutCarousel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Modules.Shortcut
{
    [Export(typeof(IShortcutViewModel))]
    public class ShortcutViewModel : NotificationObject, IShortcutViewModel
    {
        private IDataService dataService;

        [ImportingConstructor]
        public ShortcutViewModel(IDataService dataService, IEventAggregator eventAggregator)
        {
            this.dataService = dataService;
            this.CarouselUser = this.dataService.LoadUserByName("thomas");
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
        
    }
}
