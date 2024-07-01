using Microsoft.EntityFrameworkCore;
using ConfidenceFactorAssessment.API.Infrastructure.EntityConfiguration;

namespace ConfidenceFactorAssessment.API.Infrastructure;

public class ConfidenceFactorAssessmentContext : DbContext
{
    public DbSet<Assessment> Assessments { get; set; }
    public DbSet<Criteria> Criterias { get; set; }
    public DbSet<ConfidenceFactor> ConfidenceFactors { get; set; }

    public ConfidenceFactorAssessmentContext(DbContextOptions<ConfidenceFactorAssessmentContext> options,
                               IConfiguration configuration)
             : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
       
        builder.ApplyConfiguration(new AssessmentEntityConfiguration());
        builder.ApplyConfiguration(new CriteriaEntityConfiguration());
        builder.ApplyConfiguration(new ConfidenceFactorEntityConfiguration());
    }
}

