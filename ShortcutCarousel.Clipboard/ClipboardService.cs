using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShortcutCarousel.Clipboard
{
    [Export(typeof(IClipboardService))]
	public class ClipboardService : IClipboardService
	{
		public void CopyToClipboard(string copiedContent)
		{
			System.Windows.Clipboard.SetText(copiedContent);
		}
	}
}
