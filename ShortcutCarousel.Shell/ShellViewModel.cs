using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;
using System.ComponentModel.Composition;
using ShortcutCarousel.Settings;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using System.Windows;

namespace ShortcutCarousel.Shell
{
    [Export(typeof(ShellViewModel))]
    public class ShellViewModel : NotificationObject
    {
        private IApplicationSettings applicationSettings;

        [ImportingConstructor]
        public ShellViewModel(IApplicationSettings applicationSettings)
        {
            this.applicationSettings = applicationSettings;
        }

        #region WindowWidth
        public int WindowWidth
        {
            get
            {
                return this.applicationSettings.WindowWidth;
            }
            set
            {
                if (this.applicationSettings.WindowWidth != value)
                {
                    this.applicationSettings.WindowWidth = value;
                    this.RaisePropertyChanged(() => this.WindowWidth);
                }
            }
        }
        #endregion WindowWidth

        #region WindowHeight
        public int WindowHeight
        {
            get
            {
                return this.applicationSettings.WindowHeight;
            }
            set
            {
                if (this.applicationSettings.WindowHeight != value)
                {
                    this.applicationSettings.WindowHeight = value;
                    this.RaisePropertyChanged(() => this.WindowHeight);
                }
            }
        }
        #endregion WindowHeight

        #region WindowStayOnTop
        public bool WindowStayOnTop
        {
            get
            {
                return this.applicationSettings.WindowStayOnTop;
            }
            set
            {
                if (this.applicationSettings.WindowStayOnTop != value)
                {
                    this.applicationSettings.WindowStayOnTop = value;
                    this.RaisePropertyChanged(() => this.WindowStayOnTop);
                }
            }
        }
        #endregion WindowStayOnTop

        #region WindowLeft
        public int WindowLeft
        {
            get
            {
                return this.applicationSettings.WindowLeft;
            }
            set
            {
                if (this.applicationSettings.WindowLeft != value)
                {
                    this.applicationSettings.WindowLeft = value;
                    this.RaisePropertyChanged(() => this.WindowLeft);
                }
            }
        }
        #endregion WindowLeft

        #region WindowTop
        public int WindowTop
        {
            get
            {
                return this.applicationSettings.WindowTop;
            }
            set
            {
                if (this.applicationSettings.WindowTop != value)
                {
                    this.applicationSettings.WindowTop = value;
                    this.RaisePropertyChanged(() => this.WindowTop);
                }
            }
        }
        #endregion WindowTop

        #region SaveWindowWidthCommand
        private ICommand saveWindowWidthCommand;
        public ICommand SaveWindowWidthCommand
        {
            get
            {
                if (this.saveWindowWidthCommand == null)
                {
                    this.saveWindowWidthCommand = new DelegateCommand(this.ExecuteSaveWindowWidth, this.CanExecuteSaveWindowWidth);
                }
                return this.saveWindowWidthCommand;
            }
        }

        public void ExecuteSaveWindowWidth()
        {
            this.applicationSettings.Save();
        }

        public bool CanExecuteSaveWindowWidth()
        {
            return true;
        }
        #endregion SaveWindowWidthCommand
    }
}
