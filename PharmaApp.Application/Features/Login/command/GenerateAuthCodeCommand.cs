using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaApp.Application.Features.Login.command
{
    public class GenerateAuthCodeCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }

}
