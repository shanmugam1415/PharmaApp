using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaApp.Domain.model
{
    public class UserProfileResponce
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int? CarrierId { get; set; }
        public int? UserStatusId { get; set; }
        public int? CarrierStatusId { get; set; }
        public int? StatusId { get; set; }

        public string Token { get; set; }
    }

}
