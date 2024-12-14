using MediatR;
using PharmaApp.Domain.Common;
using PharmaApp.Domain.model.DTO;

namespace PharmaApp.Application.Features.Command.DespensePrescription
{
    public class DespensePrescriptionCommand : IRequest<bool>
    {
        public int PrescriptionId { get; set; }
    }
}