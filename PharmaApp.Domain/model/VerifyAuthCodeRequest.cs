using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaApp.Domain.model
{
    public class VerifyAuthCodeRequest
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
    }

}
