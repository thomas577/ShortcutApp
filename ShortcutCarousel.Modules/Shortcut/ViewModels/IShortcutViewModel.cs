using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortcutCarousel.Model;
using System.Windows.Input;
using System.ComponentModel;

namespace ShortcutCarousel.Modules.Shortcut
{
    public interface IShortcutViewModel : INotifyPropertyChanged
    {
        ICarouselUser CarouselUser { get; set; }
		ICommand EditCommand { get; }
    }
}
