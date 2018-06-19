using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ShortcutCarousel.Model;

namespace ShortcutCarousel.Modules.Shortcut
{
    public class FileDropItemToViewModelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ICarouselFileDropItem item = value as ICarouselFileDropItem;
            if (item != null)
            {
                return new ShortcutFileDropItemViewModel(item);
            }
            else
            {
                return Binding.DoNothing;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
