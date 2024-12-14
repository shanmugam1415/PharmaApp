using MediatR;
using PharmaApp.Domain.model.DTO;

namespace PharmaApp.Application.Features.Command.Create
{
    public class CreatePatientCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}