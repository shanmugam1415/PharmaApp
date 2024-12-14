using MediatR;
using PharmaApp.Domain.model.DTO;

namespace PharmaApp.Application.Features.Command.Create
{
    public class UserCommand : IRequest<UserCommandResponse>
    {
        public UserDto UserDetail { get; set; }
        //public CarrierDto Carrier { get; set; }
        public List<InsuranceDocumentDto> Documents { get; set; }
    }
}