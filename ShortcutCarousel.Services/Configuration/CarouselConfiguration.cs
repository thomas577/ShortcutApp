using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShortcutCarousel.Services
{
    [DataContract]
    public class CarouselConfiguration : ICarouselConfiguration
    {
        public CarouselConfiguration()
        {

        }

        [DataMember]
        public int WindowWidth
        {
            get;
            set;
        }
    }
}
