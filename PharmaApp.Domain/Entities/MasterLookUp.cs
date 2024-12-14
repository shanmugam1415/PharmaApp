using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaApp.Domain.Common;

namespace PharmaApp.Domain.Entities
{
    public class MasterLookUp
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string? DisplayMessage { get; set; }
        public string? Description { get; set; }
        public int? LinkId { get; set; }
    }
}
