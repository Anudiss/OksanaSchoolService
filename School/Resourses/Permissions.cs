using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace School.Resourses
{
    public static class Permissions
    {
        private static readonly Dictionary<PermissionRole, Permission[]> ProhibitionPermissions = new Dictionary<PermissionRole, Permission[]>()
        {
            { PermissionRole.Client, new[]
                {
                    Permission.AddService,
                    Permission.RemoveService,
                    Permission.EditService
                }
            }
        };

        public static bool Has(this Permission permission) =>
            StaticData.AuthtorizatedUser != null &&
           (!ProhibitionPermissions.ContainsKey(StaticData.AuthtorizatedUser.PermissionRole) ||
            !ProhibitionPermissions[StaticData.AuthtorizatedUser.PermissionRole].Contains(permission));
    }

    [ValueConversion(typeof(Permission), typeof(Visibility))]
    public class PermissionToVisiblityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is Permission permission == false)
                throw new ArgumentException("Неверный тип, ожидается Permission");

            return permission.Has() ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }

    public enum Permission
    {
        AddService,
        RemoveService,
        EditService
    }

    public enum PermissionRole
    {
        Admin = 1,
        Client = 2
    }
}
