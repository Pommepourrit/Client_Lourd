using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MegaCastingApp.Converters
{
        public class NullToFalseConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value == null ? false : true;

                //if (value == null)
                //{
                //    return false;
                //}
                //return true;

                ////if (value == null)
                ////{
                ////    return false;
                ////}
                ////else
                ////{
                ////    return true;
                ////}
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }

