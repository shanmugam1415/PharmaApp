using MediatR;
using PharmaApp.Domain.model.DTO;

namespace PharmaApp.Application.Features.Command.AddInsurance
{
    public class AddInsuranceCommand : IRequest<bool>
    {
        public int PatientId { get; set; }
        public string CompanyName { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyValidity { get; set; }
    }
}