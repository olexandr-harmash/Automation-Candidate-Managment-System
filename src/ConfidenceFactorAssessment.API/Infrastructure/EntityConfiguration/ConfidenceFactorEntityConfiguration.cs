using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfidenceFactorAssessment.API.Infrastructure.EntityConfiguration;

public class ConfidenceFactorEntityConfiguration : IEntityTypeConfiguration<ConfidenceFactor>
{
    public void Configure(EntityTypeBuilder<ConfidenceFactor> builder)
    {
        builder.HasOne(x => x.Assessment)
            .WithMany(x => x.ConfidenceFactors);

        builder.HasOne(x => x.Criteria)
            .WithMany();
    }
}
