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
using Microsoft.Practices.Prism.Events;
using ShortcutCarousel.Events;
using ShortcutCarousel.Model;

namespace ShortcutCarousel.Shell
{
    [Export(typeof(ShellViewModel))]
    public class ShellViewModel : NotificationObject
    {
        private IApplicationSettings applicationSettings;
		private IEventAggregator eventAggregator;

		[ImportingConstructor]
        public ShellViewModel(IApplicationSettings applicationSettings, IEventAggregator eventAggregator)
        {
            this.applicationSettings = applicationSettings;
			this.eventAggregator = eventAggregator;

			this.eventAggregator.GetEvent<EditUserEvent>().Subscribe(this.OpenEditorFor);
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

        #region SaveWindowSettingsCommand
        private ICommand saveWindowSettingsCommand;
        public ICommand SaveWindowSettingsCommand
        {
            get
            {
                if (this.saveWindowSettingsCommand == null)
                {
                    this.saveWindowSettingsCommand = new DelegateCommand(this.ExecuteSaveWindowSettings, this.CanExecuteSaveWindowSettings);
                }
                return this.saveWindowSettingsCommand;
            }
        }

        public void ExecuteSaveWindowSettings()
        {
            this.applicationSettings.Save();
        }

        public bool CanExecuteSaveWindowSettings()
        {
            return true;
        }
        #endregion SaveWindowSettingsCommand

		private void OpenEditorFor(ICarouselUser user)
		{
			new EditorWindow().Show();
		}
    }
}
