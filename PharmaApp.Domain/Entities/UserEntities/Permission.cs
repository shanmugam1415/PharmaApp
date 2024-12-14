using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaApp.Domain.Entities.UserEntities
{
    public class Permission
    {
        public int Id { get; set; }

        public string PermissionName { get; set; }
        public string Description { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
