using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace PrismApplicationTemplate.Converters
{
	[ValueConversion(typeof(int), typeof(bool))]
	public class RadioButtonConverter : IValueConverter
	{
		public object Convert(object value, Type t, object parameter, CultureInfo culture)
		{
			return value.Equals(parameter);
		}

		public object ConvertBack(object value, Type t, object parameter, CultureInfo culture)
		{
			return value.Equals(false) ? DependencyProperty.UnsetValue : parameter;
		}
	}
}
