using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Settings
{
    public interface IApplicationSettings : IWindowSettings, ICarouselColorSettings, ICarouselUsersSavePath
    {
        object GetPreviousVersion(string propertyName);
        void Reload();
        void Reset();
        void Save();
        void Upgrade();
    }
}
