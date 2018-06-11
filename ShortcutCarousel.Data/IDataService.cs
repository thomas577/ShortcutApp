using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortcutCarousel.Model;

namespace ShortcutCarousel.Data
{
	public interface IDataService
	{
        ICarouselUser LoadUserByName(string name);
        void SaveUser(ICarouselUser user);
	}
}
