using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaApp.Application.Features.User.Command.Update
{
    public class UserProfileUpdateCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; } 
    }

}
