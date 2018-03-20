﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TokeiLibrary;

namespace SDE.WPF
{
    public class ListViewWItemWidthConverter : IValueConverter {
		private readonly double _offset;

		public ListViewWItemWidthConverter() {
		}

		public ListViewWItemWidthConverter(Thickness thick) {
			if (thick.Right != 0)
				_offset++;
			if (thick.Left != 0)
				_offset++;

			_offset = thick.Left + thick.Right + _offset;
		}

		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (!(value is double))
				return value;

			double offset = 0;
			double currentValue = (double)value;

			if (currentValue <= 0)
				return currentValue;

			ListView parameterView = parameter as ListView;
			if (parameterView != null) {
				if (_isScrollBarVisible(parameterView)) {
					offset = -SystemParameters.VerticalScrollBarWidth;
				}

				currentValue = parameterView.ActualWidth + offset - _offset;
			}

			if (currentValue < 0)
				return 0;

			return currentValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}

		#endregion

		private static bool _isScrollBarVisible(DependencyObject view) {
			ScrollViewer[] sv = WpfUtilities.FindChildren<ScrollViewer>(view);

			if (sv.Length > 0)
				return sv[0].ComputedVerticalScrollBarVisibility == Visibility.Visible;

			return false;
		}
	}
}
