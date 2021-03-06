﻿using System;
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
	/// Interaction logic for EditorCopyPasteDetailsView.xaml
	/// </summary>
	[Export(typeof(EditorCopyPasteDetailsView))]
	public partial class EditorCopyPasteDetailsView : UserControl
    {
        public EditorCopyPasteDetailsView()
        {
            InitializeComponent();
        }

		[ImportingConstructor]
		public EditorCopyPasteDetailsView(IEditorCopyPasteDetailsViewModel editorCopyPasteDetailsViewModel)
			: this()
		{
			this.DataContext = editorCopyPasteDetailsViewModel;
		}
	}
}
