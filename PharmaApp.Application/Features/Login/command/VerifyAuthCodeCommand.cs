using MediatR;

namespace PharmaApp.Application.Features.Login.command
{
    public class VerifyAuthCodeCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }

        public VerifyAuthCodeCommand(int userid,string email, string token)
        {
            UserId = userid;
            Email = email;
            Code = token;
        }
    }

}
