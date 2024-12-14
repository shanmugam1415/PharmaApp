using MediatR;
using Microsoft.Extensions.Logging;
using PharmaApp.Application.Repositories;
using PharmaApp.Domain.model;

namespace PharmaApp.Application.Features.Login.command
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, UserProfileResponce>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ILogger<LoginCommandHandler> _logger;

        public LoginCommandHandler(IUserRepository userRepository, ITokenService tokenService, ILogger<LoginCommandHandler> logger)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<UserProfileResponce> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _userRepository.GetByUsernameAndPasswordAsync(request.Username, request.Password);
                if (data == null) {
                    throw new Exception("Invalid UserName or Password");
                }
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
           
        }
    }


}
