using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Modularity;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.ServiceLocation;

namespace ShortcutCarousel.Modules.Editor
{
    [ModuleExport(typeof(EditorModule))]
    public class EditorModule : IModule
    {
        private IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public EditorModule(IRegionViewRegistry regionViewRegistry)
        {
            this.regionViewRegistry = regionViewRegistry;
        }

        public void Initialize()
        {
            this.regionViewRegistry.RegisterViewWithRegion("EditorRegion", typeof(EditorView));
            this.regionViewRegistry.RegisterViewWithRegion("EditorFileDropDetails", typeof(EditorFileDropDetailsView));
			this.regionViewRegistry.RegisterViewWithRegion("EditorCopyPasteDetails", typeof(EditorCopyPasteDetailsView));
		}
	}
}
