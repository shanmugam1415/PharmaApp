using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaApp.Domain.model.DTO
{
    public class UserProfileDto
    {
        public UserDto UserDetail { get; set; }
        public CarrierDto Carrier { get; set; }
    }
}
