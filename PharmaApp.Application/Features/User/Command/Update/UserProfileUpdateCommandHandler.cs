using Cqrs.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaApp.Application.Common.Exceptions;
using PharmaApp.Application.Repositories;

namespace PharmaApp.Application.Features.User.Command.Update
{
    public class UserProfileUpdateCommandHandler : IRequestHandler<UserProfileUpdateCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public UserProfileUpdateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UserProfileUpdateCommand request, CancellationToken cancellationToken)
        {
            var userDetails = await _userRepository.GetByIdAsync(request.UserId);

            if (userDetails != null)
            {
                userDetails.PhoneNumber = request.PhoneNumber;
                userDetails.Fax = request.Fax;
                userDetails.Address = request.Address;
                userDetails.RoleId=request.RoleId;
                await _userRepository.Update(userDetails);
                return true;
            }
            else { 
            throw new ApplicationException("User Not Found");
            }
        }
    }

}
