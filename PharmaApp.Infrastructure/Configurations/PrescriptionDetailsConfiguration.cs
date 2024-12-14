using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PharmaApp.Domain.Entities;

namespace PharmaApp.Infrastructure.Configurations
{
    public class PrescriptionDetailsConfiguration : IEntityTypeConfiguration<PrescriptionDetails>
    {
        public void Configure(EntityTypeBuilder<PrescriptionDetails> builder)
        {
            // Table Name
            builder.ToTable("prescriptionDetails");

            // Primary Key
            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.PrescriptionId).IsRequired();
            builder.Property(p => p.MedicationName).IsRequired();
            builder.Property(p => p.MedicationCode).IsRequired();
            builder.Property(p => p.Dosage).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.DaysSupply).IsRequired();

        }
    }

}
