using ShortcutCarousel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ShortcutCarousel.Modules.Editor
{
	public interface IEditorCopyPasteDetailsViewModel : INotifyPropertyChanged
	{
		string DisplayName { get; set; }
		Color ColorBackground { get; }
		ColorType ColorType { get; set; }
		double ColorHue { get; set; }
		double ColorLuminosity { get; set; }
		string Content { get; set; }
	}
}
