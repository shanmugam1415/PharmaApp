using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaApp.Domain.model.DTO
{
    public class InsuranceDocumentDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DocumentType { get; set; }
        public IFormFile Document { get; set; }

        public int? CarrierId { get; set; }

        public int UserId { get; set; }
    }
}
