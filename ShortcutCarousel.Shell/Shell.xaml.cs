using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace ShortcutCarousel.Shell
{
	/// <summary>
	/// Interaction logic for Shell.xaml
	/// </summary>
	[Export]
	public partial class Shell : MetroWindow
    {
		public Shell()
		{
			InitializeComponent();
		}

        [ImportingConstructor]
        public Shell(ShellViewModel shellViewModel) : this()
        {
            this.DataContext = shellViewModel;
        }

        private void MetroWindow_Drop(object sender, DragEventArgs e)
        {
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				// Note that you can have more than one file.
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				MessageBox.Show(string.Join(Environment.NewLine, files));
			}
			else
			{
				MessageBox.Show(e.Data.GetData(DataFormats.Text).ToString());

			}
        }

		private void MetroWindow_DragEnter(object sender, DragEventArgs e)
		{
			this.Background = new SolidColorBrush(Colors.Red);
		}

		private void MetroWindow_DragLeave(object sender, DragEventArgs e)
		{
			this.Background = new SolidColorBrush(Colors.Green);
		}
	}
}
