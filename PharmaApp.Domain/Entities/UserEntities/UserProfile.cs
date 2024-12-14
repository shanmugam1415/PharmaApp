using System;

using PharmaApp.Domain.Common;

namespace PharmaApp.Domain.Entities.UserEntities
{
    public class UserProfile :BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set;}
        public int RoleId { get; set; }
        public string CompanyName { get; set; }
        public string? Address { get; set; }  
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Fax { get; set; }
        public string? City { get; set; }  
        public int? StatusId { get; set; } 
    }
}
