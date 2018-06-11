using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Settings
{
    public interface IWindowSettings
    {
        int WindowWidth { get; set; }
        int WindowHeight { get; set; }
        bool WindowStayOnTop { get; set; }
        int WindowLeft { get; set; }
        int WindowTop { get; set; }
    }
}
