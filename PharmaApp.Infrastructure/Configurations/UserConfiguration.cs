using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaApp.Domain.Entities;
using PharmaApp.Domain.Entities.UserEntities;

namespace PharmaApp.Infrastructure.Configurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("userProfile").HasKey(u => u.Id);
            builder.Property(c => c.Id);

            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.EmailAddress).IsRequired();
            builder.Property(u => u.PhoneNumber).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.RoleId).IsRequired();
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.CompanyName).IsRequired();
            builder.Property(u => u.Address);
            builder.Property(u => u.State);
            builder.Property(u => u.Fax).IsRequired(false);
            builder.Property(u => u.City);
            builder.Property(u => u.PostalCode);

        }
    }
}
