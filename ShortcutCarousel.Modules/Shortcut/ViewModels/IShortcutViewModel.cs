using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortcutCarousel.Model;

namespace ShortcutCarousel.Modules.Shortcut
{
    public interface IShortcutViewModel
    {
        ICarouselUser CarouselUser { get; set; }
    }
}
