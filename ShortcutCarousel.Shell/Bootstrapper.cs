using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using ShortcutCarousel.Modules;
using ShortcutCarousel.Settings;

namespace ShortcutCarousel.Shell
{
	public class Bootstrapper : MefBootstrapper
	{
		protected override DependencyObject CreateShell()
		{
			return ServiceLocator.Current.GetInstance<Shell>();
		}

		protected override void InitializeShell()
		{
			base.InitializeShell();
            
			Application.Current.MainWindow = (Shell)this.Shell;
			Application.Current.MainWindow.Show();
		}

		protected override void ConfigureAggregateCatalog()
		{
			base.ConfigureAggregateCatalog();

			// Add this assembly to export ModuleTracker
			this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(IApplicationSettings).Assembly));

            // Module A is referenced in in the project and directly in code.
            //this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleA).Assembly));
            //this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleC).Assembly));

            // Module B and Module D are copied to a directory as part of a post-build step.
            // These modules are not referenced in the project and are discovered by inspecting a directory.
            // Both projects have a post-build step to copy themselves into that directory.
            //DirectoryCatalog catalog = new DirectoryCatalog("DirectoryModules");
            //this.AggregateCatalog.Catalogs.Add(catalog);
        }

        protected override IModuleCatalog CreateModuleCatalog()
		{
			// When using MEF, the existing Prism ModuleCatalog is still the place to configure modules via configuration files.
			return new ConfigurationModuleCatalog();
		}
	}
}
