using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaApp.Domain.Entities.UserEntities;

namespace PharmaApp.Domain.model.DTO
{
    public class BusinessServiceDTO
    {
        public int UserId { get; set; } // Foreign Key
        public int TruckLoadType { get; set; }
        public decimal? Revenue { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Industries { get; set; }
        public string CompanyEmail { get; set; } // Not nullable

        // Navigation property for Carrier relationship
        public UserProfile User { get; set; }
    }
}
