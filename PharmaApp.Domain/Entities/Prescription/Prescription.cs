
using PharmaApp.Domain.Common;

namespace PharmaApp.Domain.Entities
{
    public class Prescription : BaseEntity
    {
        public int PatientId { get; set; }
        public string DoctorName { get; set; }
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }
        public bool IsDispensed { get; set; }
        public ICollection<PrescriptionDetails> PrescriptionDetails { get; set; }

    }
}
