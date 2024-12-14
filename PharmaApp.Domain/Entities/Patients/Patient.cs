
using PharmaApp.Domain.Common;

namespace PharmaApp.Domain.Entities
{
    public class Patient: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }

    }
}
