using System;

namespace PharmaApp.Domain.model.DTO
{
    public class StateDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RegionId { get; set; }
        public string RegionName { get; set; } // Optional
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public int? CreatedBy { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
