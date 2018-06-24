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

namespace ShortcutCarousel.Modules.Editor
{
	/// <summary>
	/// Interaction logic for EditorFileDropDetailsView.xaml
	/// </summary>
	[Export(typeof(EditorFileDropDetailsView))]
	public partial class EditorFileDropDetailsView : UserControl
    {
        public EditorFileDropDetailsView()
        {
            InitializeComponent();
        }

		[ImportingConstructor]
		public EditorFileDropDetailsView(IEditorFileDropDetailsViewModel editorFileDropDetailsViewModel)
			: this()
		{
			this.DataContext = editorFileDropDetailsViewModel;
		}
    }
}
