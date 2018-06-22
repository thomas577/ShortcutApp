using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using ShortcutCarousel.Model;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel;

namespace ShortcutCarousel.Modules.Shortcut
{
    public class ShortcutFileDropItemViewModel : NotificationObject, IShortcutFileDropItemViewModel
    {
        private ICarouselFileDropItem carouselFileDropItem;

        public ShortcutFileDropItemViewModel(ICarouselFileDropItem carouselFileDropItem)
        {
            this.carouselFileDropItem = carouselFileDropItem;
            this.carouselFileDropItem.PropertyChanged += (object sender, PropertyChangedEventArgs e) => { this.RaisePropertyChanged(e.PropertyName); };
        }

        public Color ColorBackground
        {
            get
            {
                return this.carouselFileDropItem.ColorBackground;
            }
        }

        public string DisplayName
        {
            get
            {
                return this.carouselFileDropItem.DisplayName;
            }
        }

        #region ReceivedDropCommand
        private ICommand receivedDropCommand;
        public ICommand ReceivedDropCommand
        {
            get
            {
                if (this.receivedDropCommand == null)
                {
                    this.receivedDropCommand = new DelegateCommand(this.ExecuteReceivedDrop, this.CanExecuteReceivedDrop);
                }
                return this.receivedDropCommand;
            }
        }

        public void ExecuteReceivedDrop()
        {

        }

        public bool CanExecuteReceivedDrop()
        {
            return true;
        }
        #endregion ReceivedDropCommand

    }
}
