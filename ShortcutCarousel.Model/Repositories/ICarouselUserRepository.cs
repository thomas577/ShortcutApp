using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Model
{
    public interface ICarouselUserRepository
    {
        IList<ICarouselUser> GetAll();
        IList<string> GetAllNames();
        ICarouselUser GetByName(string name);
        void Save(ICarouselUser user);
    }
}
