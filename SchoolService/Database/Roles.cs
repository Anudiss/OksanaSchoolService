using SchoolService;
using System.Linq;

namespace SchoolService.Database
{
    public static class Roles
    {
        public static Role Admin => DatabaseConnection.Database.Role.First(role => role.Name == "Admin");
        public static Role Client => DatabaseConnection.Database.Role.First(role => role.Name == "Client");
    }
}
