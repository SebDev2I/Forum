using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace FIISA_Universel
{
    public class NotBoolConverter : IValueConverter
    {
        #region IValueConverter Membres

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return true;

            if (value.GetType() != typeof(bool) && targetType != typeof(bool))
                throw new InvalidCastException();

            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

