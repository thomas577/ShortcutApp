﻿using System;
using System.Collections.Generic;
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
using System.ComponentModel.Composition;

namespace ShortcutCarousel.Modules.Editor
{
    /// <summary>
    /// Interaction logic for EditorView.xaml
    /// </summary>
    [Export(typeof(EditorView))]
    public partial class EditorView : UserControl
    {
        public EditorView()
        {
            InitializeComponent();
        }

        [ImportingConstructor]
        public EditorView(IEditorViewModel editorViewModel)
            : this()
        {
            this.DataContext = editorViewModel;
        }
    }
}
