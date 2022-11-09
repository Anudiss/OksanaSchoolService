using School.Resourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public partial class User
    {
        public PermissionRole PermissionRole => (PermissionRole)Role_ID;
    }
}
