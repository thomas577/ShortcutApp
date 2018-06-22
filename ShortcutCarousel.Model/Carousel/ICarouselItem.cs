using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ShortcutCarousel.Model
{
	public interface ICarouselItem : INotifyPropertyChanged
    {
		void Clicked();
		void ReceiveDrop(IEnumerable<string> paths);

		bool AcceptsDrops { get; }
		string DisplayName { get; }
		int DisplayOrder { get; }
		Color ColorBackground { get; }
		ColorType ColorType { get; }
		double ColorHue { get; }
		double ColorLuminosity { get; }
	}
}
