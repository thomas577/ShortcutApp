using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Model
{
	public interface ICarouselUser : INotifyPropertyChanged
	{
		string Name { get; }
		IList<ICarouselCopyPasteItem> CopyPasteItems { get; }
		IList<ICarouselFileDropItem> FileDropItems { get; }
	}
}
