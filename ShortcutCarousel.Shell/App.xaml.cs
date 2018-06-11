using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShortcutCarousel.Shell
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        public App()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(string.Format("An error occured: {0}", e.Exception.Message), "Error");
            e.Handled = true;
        }

        protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			// The boostrapper will create the Shell instance, so the App.xaml does not have a StartupUri.
			Bootstrapper bootstrapper = new Bootstrapper();
			bootstrapper.Run();
		}
	}
}
