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
    public class ShortcutCopyPasteItemViewModel : NotificationObject, IShortcutCopyPasteItemViewModel
    {
        private ICarouselCopyPasteItem carouselCopyPasteItem;

        public ShortcutCopyPasteItemViewModel(ICarouselCopyPasteItem carouselCopyPasteItem)
        {
            this.carouselCopyPasteItem = carouselCopyPasteItem;
            this.carouselCopyPasteItem.PropertyChanged += (object sender, PropertyChangedEventArgs e) => { this.RaisePropertyChanged(e.PropertyName); };
        }

        public Color ColorBackground
        {
            get
            {
                return this.carouselCopyPasteItem.ColorBackground;
            }
        }

        public string DisplayName
        {
            get
            {
                return this.carouselCopyPasteItem.DisplayName;
            }
        }

        #region ClickedCommand
        private ICommand clickedCommand;
        public ICommand ClickedCommand
        {
            get
            {
                if (this.clickedCommand == null)
                {
                    this.clickedCommand = new DelegateCommand(this.ExecuteClicked, this.CanExecuteClicked);
                }
                return this.clickedCommand;
            }
        }

        public void ExecuteClicked()
        {

        }

        public bool CanExecuteClicked()
        {
            return true;
        }
        #endregion ClickedCommand


    }
}
