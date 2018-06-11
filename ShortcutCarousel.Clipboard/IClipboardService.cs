using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Clipboard
{
	public interface IClipboardService
	{
		void CopyToClipboard(string copiedContent);
	}
}
