using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaApp.Domain.Entities;

namespace PharmaApp.Infrastructure.Configurations
{
    public class MasterLookUpConfiguration : IEntityTypeConfiguration<MasterLookUp>
    {
        public void Configure(EntityTypeBuilder<MasterLookUp> builder)
        {
            // Table Name
            builder.ToTable("masterLookUp");

            // Primary Key
            builder.HasKey(ce => ce.Id);

            // Properties
            builder.Property(ce => ce.Type);
            builder.Property(ce => ce.Code);
            builder.Property(ce => ce.DisplayMessage);
            builder.Property(ce => ce.Description);
            builder.Property(ce => ce.LinkId);
        }
    }

}
