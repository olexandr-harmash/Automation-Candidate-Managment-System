using Microsoft.EntityFrameworkCore;

using ConfidenceFactorAssessment.API.Repository.Abstractions;

namespace ConfidenceFactorAssessment.API.Repository;

public class ConfidenceFactorRepository : RepositoryBase<ConfidenceFactor, ConfidenceFactorAssessmentContext>, IConfidenceFactorRepository
{
    public ConfidenceFactorRepository(ConfidenceFactorAssessmentContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateConfidenceFactor(Guid assessmentId, Guid criteriaId, ConfidenceFactor confidenceFactor)
    {
        confidenceFactor.AssessmentId = assessmentId;
        confidenceFactor.CriteriaId = criteriaId;
        Create(confidenceFactor);
    }

    public void DeleteConfidenceFactor(ConfidenceFactor confidenceFactor) => Delete(confidenceFactor);

    public async Task<IEnumerable<ConfidenceFactor>> FetchConfidenceFactor(Guid assessmentId, IEnumerable<Guid> criteriaIds, bool trackChanges) =>
        await FindByCondition(x => assessmentId.Equals(x.Id) && criteriaIds.Contains(x.CriteriaId), trackChanges).ToListAsync();

    public async Task<ConfidenceFactor?> GetConfidenceFactor(Guid assessmentId, Guid criteriaId, bool trackChanges) =>
        await FindByCondition(x => assessmentId.Equals(x.AssessmentId) && criteriaId.Equals(x.CriteriaId), trackChanges).SingleOrDefaultAsync();
}
