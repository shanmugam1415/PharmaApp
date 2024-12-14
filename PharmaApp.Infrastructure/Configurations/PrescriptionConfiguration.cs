using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PharmaApp.Domain.Entities;

namespace PharmaApp.Infrastructure.Configurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            // Table Name
            builder.ToTable("prescription");

            // Primary Key
            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.PatientId).IsRequired();
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.IsDispensed).IsRequired();
            builder.Property(p => p.DoctorName).IsRequired();

        }
    }

}
