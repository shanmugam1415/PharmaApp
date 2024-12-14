using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PharmaApp.Domain.Entities;

namespace PharmaApp.Infrastructure.Configurations
{
    public class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
    {
        public void Configure(EntityTypeBuilder<Insurance> builder)
        {
            // Table Name
            builder.ToTable("insurance");

            // Primary Key
            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.PatientId).IsRequired();
            builder.Property(p => p.CompanyName).IsRequired();
            builder.Property(p => p.PolicyNumber).IsRequired();
            builder.Property(p => p.PolicyValidity).IsRequired();

        }
    }

}
