using Microsoft.EntityFrameworkCore;

using ConfidenceFactorAssessment.API.Repository.Abstractions;

namespace ConfidenceFactorAssessment.API.Repository;

public class AssessmentRepository : RepositoryBase<Assessment, ConfidenceFactorAssessmentContext>, IAssessmentRepository
{
    public AssessmentRepository(ConfidenceFactorAssessmentContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateAssessment(Assessment assessment) => Create(assessment);

    public void DeleteAssessment(Assessment assessment) => Delete(assessment);

    public async Task<Assessment?> GetAssessmentById(Guid id, bool trackChanges) =>
        await FindByCondition(x => id.Equals(x.Id), trackChanges).Include(e => e.ConfidenceFactors).SingleOrDefaultAsync();
}
