using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;

namespace FIISA_Universel
{
    public sealed class BooleanToVisibilityConverter : BooleanConverter<Visibility>
    {
        public BooleanToVisibilityConverter() : base(Visibility.Visible, Visibility.Collapsed){ }
    }
}
