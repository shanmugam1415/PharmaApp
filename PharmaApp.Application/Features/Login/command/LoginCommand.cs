using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaApp.Domain.model;

namespace PharmaApp.Application.Features.Login.command
{
    public class LoginCommand : IRequest<UserProfileResponce>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
