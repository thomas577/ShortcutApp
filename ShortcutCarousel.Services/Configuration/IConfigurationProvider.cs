using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Services
{
    public interface IConfigurationProvider
    {
        ICarouselConfiguration GetCarouselConfiguration();
        void SaveCarouselConfiguration(ICarouselConfiguration carouselConfiguration);
    }
}
