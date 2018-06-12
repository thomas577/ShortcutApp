using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortcutCarousel.Settings;
using System.ComponentModel.Composition;

namespace ShortcutCarousel.Shell
{
	[Export(typeof(IApplicationSettings))]
	[Export(typeof(IWindowSettings))]
	[Export(typeof(ICarouselColorSettings))]
	[Export(typeof(ICarouselUsersSavePath))]
	public class ApplicationSettings :
		IApplicationSettings,
		IWindowSettings,
		ICarouselColorSettings,
		ICarouselUsersSavePath
	{
		private Properties.Settings settings;

		[ImportingConstructor]
		public ApplicationSettings()
		{
			this.settings = Properties.Settings.Default;
		}

		public string CarouselUsersSavePath
		{
			get
			{
				return this.settings.CarouselUsersSavePath;
			}
		}

		public double DefaultLuminosity
		{
			get
			{
				return this.settings.DefaultLuminosity;
			}
		}

		public int WindowHeight
		{
			get
			{
				return this.settings.WindowHeight;
			}

			set
			{
				this.settings.WindowHeight = value;
			}
		}

		public int WindowLeft
		{
			get
			{
				return this.settings.WindowLeft;
			}

			set
			{
				this.settings.WindowLeft = value;
			}
		}

		public bool WindowStayOnTop
		{
			get
			{
				return this.settings.WindowStayOnTop;
			}

			set
			{
				this.settings.WindowStayOnTop = value;
			}
		}

		public int WindowTop
		{
			get
			{
				return this.settings.WindowTop;
			}

			set
			{
				this.settings.WindowTop = value;
			}
		}

		public int WindowWidth
		{
			get
			{
				return this.settings.WindowWidth;
			}

			set
			{
				this.settings.WindowWidth = value;
			}
		}

		public object GetPreviousVersion(string propertyName)
		{
			return this.settings.GetPreviousVersion(propertyName);
		}

		public void Reload()
		{
			this.settings.Reload();
		}

		public void Reset()
		{
			this.settings.Reset();
		}

		public void Save()
		{
			this.settings.Save();
		}

		public void Upgrade()
		{
			this.settings.Upgrade();
		}
	}
}
