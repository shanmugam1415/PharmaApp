using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaApp.Domain.Entities.UserEntities;

namespace PharmaApp.Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles").HasKey(r => r.Id);

            builder.Property(c => c.Id);

            builder.Property(r => r.RoleName)
                .IsRequired();

            builder.Property(r => r.Description);
        }

    }
}
