
using PharmaApp.Domain.Common;

namespace PharmaApp.Domain.Entities
{
    public class PrescriptionDetails : BaseEntity
    {
        public int PrescriptionId { get; set; }
        public string MedicationName { get; set; }
        public string MedicationCode { get; set; }
        public string Dosage { get; set; }
        public int Quantity { get; set; }
        public int DaysSupply { get; set; }

    }
}
