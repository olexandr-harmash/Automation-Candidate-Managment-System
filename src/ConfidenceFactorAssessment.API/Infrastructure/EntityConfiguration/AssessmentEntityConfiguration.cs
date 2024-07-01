using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfidenceFactorAssessment.API.Infrastructure.EntityConfiguration;

public class AssessmentEntityConfiguration : IEntityTypeConfiguration<Assessment>
{
    public void Configure(EntityTypeBuilder<Assessment> builder)
    {
        builder.Property(x => x.CreatedBy).IsRequired()
            .HasMaxLength(50);

        builder.HasMany(x => x.ConfidenceFactors)
            .WithOne(x => x.Assessment);
    }
}
