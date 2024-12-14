using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaApp.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }         
        public int? LastModifiedBy { get; set; }            
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }

    }
}
