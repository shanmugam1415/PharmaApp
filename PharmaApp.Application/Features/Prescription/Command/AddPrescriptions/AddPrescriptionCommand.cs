using MediatR;
using PharmaApp.Domain.Common;
using PharmaApp.Domain.model.DTO;

namespace PharmaApp.Application.Features.Command.AddPrescription
{
    public class AddPrescriptionCommand : IRequest<bool>
    {
        public int PatientId { get; set; }
        public string DoctorName { get; set; }
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }
        public bool IsDispensed { get; set; }
        public List<PrescriptionDetailsDto> PrescriptionDetails { get; set; }
    }
    public class PrescriptionDetailsDto
    {
        public string MedicationName { get; set; }
        public string MedicationCode { get; set; }
        public string Dosage { get; set; }
        public int Quantity { get; set; }
        public int DaysSupply { get; set; }

    }
}