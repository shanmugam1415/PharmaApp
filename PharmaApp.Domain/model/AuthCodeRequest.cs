using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaApp.Domain.model
{
    public class AuthCodeRequest
    {
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }

}
