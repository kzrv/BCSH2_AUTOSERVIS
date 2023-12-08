using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Kozyrev_Hriha_SP.Models.Enum;

namespace Kozyrev_Hriha_SP.Utils
{
    public class RoleToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Role currentUserRole && parameter is string targetRoles)
            {
                var roles = targetRoles.Split(',').Select(r => r.Trim());
                return roles.Contains(currentUserRole.ToString()) ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}