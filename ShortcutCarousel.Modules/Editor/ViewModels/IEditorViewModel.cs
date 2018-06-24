using ShortcutCarousel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Modules.Editor
{
    public interface IEditorViewModel : INotifyPropertyChanged
    {
		ICarouselUser CarouselUser { get; set; }
		ICarouselCopyPasteItem CopyPasteItemSelected { get; set; }
		ICarouselFileDropItem FileDropItemSelected { get; set; }
	}
}
