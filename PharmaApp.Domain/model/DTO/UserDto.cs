using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaApp.Domain.model.DTO
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Password { get; set; }
        public string CompanyName { get; set; } 
        public string Address { get; set; } 
        public string PostalCode { get; set; } 
        public string State { get; set; } 
        public string City { get; set; } 
        public string Fax { get; set; } 
        public IFormFile Logo { get; set; } 
        public string DotNumber { get; set; } 
        

        public int Id { get; set; }

        public int InviteUserId { get; set; }
     
        public int UserType { get; set; } 
        public int? CarrierId { get; set; }


  
     
  
 





  

  
   
     
    
     
    }
}
