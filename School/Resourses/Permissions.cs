using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Resourses
{
    public static class Permissions
    {
        private static readonly Dictionary<PermissionRole, Permission[]> ProhibitionPermissions = new Dictionary<PermissionRole, Permission[]>()
        {
            { PermissionRole.Client, new[]
                {
                    Permission.AddService,
                    Permission.RemoveService
                }
            }
        };

        public static bool HasPermision(Permission permission)
        {
            if (StaticData.AuthtorizatedUser == null)
                throw new NullReferenceException("Пользователь не авторизован");

            return !ProhibitionPermissions[StaticData.AuthtorizatedUser.PermissionRole].Contains(permission);
        }
    }

    public enum Permission
    {
        AddService,
        RemoveService
    }

    public enum PermissionRole
    {
        Admin = 0,
        Client = 1
    }
}
