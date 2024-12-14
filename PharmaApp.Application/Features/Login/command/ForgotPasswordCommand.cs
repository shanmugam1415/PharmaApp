using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaApp.Application.Features.Login.command
{
    public class ForgotPasswordCommand : IRequest<bool>
    {
        public string Email { get; set; }
    }

}
