using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShortcutCarousel.Clipboard
{
	public class ClipboardService : IClipboardService
	{
		public void CopyToClipboard(string copiedContent)
		{
			System.Windows.Clipboard.SetText(copiedContent);
		}
	}
}
