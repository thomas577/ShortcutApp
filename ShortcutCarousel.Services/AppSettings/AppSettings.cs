using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel.Composition;

namespace ShortcutCarousel.Services
{
    [Export(typeof(IAppSettings))]
    [Export(typeof(IUserXmlConfigurationPath))]
    class AppSettings : IAppSettings
    {
        public string UserXmlConfigurationPath
        {
            get
            {
                return ConfigurationManager.AppSettings["UserXmlConfigurationPath"];
            }
        }
    }
}
