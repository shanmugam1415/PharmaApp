using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaApp.Domain.model.DTO
{
    public class CarrierDto
    {
        public int CarrierId { get; set; } 
        public string DotNumber { get; set; }

        public List<EquipmentTypeDto> EquipmentTypes { get; set; } 

        public List<LanePreferenceDto> LanePreferences { get; set; } 

        public List<InsuranceDocumentDto> InsuranceDocuments { get; set; } 

        public List<SignatureDto> Signatures { get; set; }
    }
}
