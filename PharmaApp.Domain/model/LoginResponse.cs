using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaApp.Domain.model
{
    public class LoginResponse
    {
        public UserProfileResponce UserProfile { get; set; }
        public string Token { get; set; }
    }

}
