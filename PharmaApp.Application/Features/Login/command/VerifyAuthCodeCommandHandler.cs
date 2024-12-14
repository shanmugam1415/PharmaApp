using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaApp.Application.Repositories;

namespace PharmaApp.Application.Features.Login.command
{
    public class VerifyAuthCodeCommandHandler : IRequestHandler<VerifyAuthCodeCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public VerifyAuthCodeCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
       
        public async Task<bool> Handle(VerifyAuthCodeCommand request, CancellationToken cancellationToken)
        {
            var result =  await _userRepository.VerifyTwoFactorCodeAsync(request.Email,request.UserId, request.Code);

            return result;
        }
    }

}
