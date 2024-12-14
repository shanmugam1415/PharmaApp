
using PharmaApp.Domain.Common;

namespace PharmaApp.Domain.Entities
{
    public class Insurance : BaseEntity
    {
        public int PatientId { get; set; }
        public string CompanyName { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyValidity { get; set; }

    }
}
