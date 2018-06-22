using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ShortcutCarousel.Modules.Shortcut
{
    public interface IShortcutFileDropItemViewModel : INotifyPropertyChanged
    {
        string DisplayName { get; }
        Color ColorBackground { get; }
        //ICommand ClickedCommand { get; }
        ICommand ReceivedDropCommand { get; }
    }
}
