using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaApp.Application.Repositories;

namespace PharmaApp.Application.Features.Login.command
{
    public class GenerateAuthCodeCommandHandler : IRequestHandler<GenerateAuthCodeCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public GenerateAuthCodeCommandHandler(IUserRepository userRepository) 
        {
           _userRepository = userRepository;
        }
        public async Task<bool> Handle(GenerateAuthCodeCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetByUsernameAndPasswordAsync(request.EmailId,request.Password);
            return true; 
        }
    }

}
