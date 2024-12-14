using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaApp.Domain.model.DTO
{
    public class SignatureDto
    {
        public string Name { get; set; } 
        public int Type { get; set; } 
        public IFormFile File { get; set; } 
    }
}
