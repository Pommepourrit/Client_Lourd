using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MegaCastingApp.Converters
{
    public class FalseToVisibleConverter : IValueConverter
    {
        //Permet de jouer avec la visibilité d'une image ex ne l'afficher que si le boolean isOk == true
        //convertit l'objet d'entrée en un nouveau type
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //On ne la définira pas, on fait une conversion unidirectionnelle
            //OneWay
            throw new NotImplementedException();
        }
    }
}
