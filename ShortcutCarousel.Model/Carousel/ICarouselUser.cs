using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Model
{
	public interface ICarouselUser
	{
		string Name { get; }
		IList<ICarouselItem> CopyPasteItems { get; }
		IList<ICarouselItem> FileDropItems { get; }
	}
}
