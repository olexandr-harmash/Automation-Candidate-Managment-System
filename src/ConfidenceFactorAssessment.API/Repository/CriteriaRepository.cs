using Microsoft.EntityFrameworkCore;

using ConfidenceFactorAssessment.API.Repository.Abstractions;

namespace ConfidenceFactorAssessment.API.Repository;

public class CriteriaRepository : RepositoryBase<Criteria, ConfidenceFactorAssessmentContext>, ICriteriaRepository
{
    public CriteriaRepository(ConfidenceFactorAssessmentContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateCriteriaCollection(IEnumerable<Criteria> criteriaCollection, bool trackChanges)
    {
        foreach (var criteria in criteriaCollection)
        {
            Create(criteria);
        }
    }

    public async Task<IEnumerable<Criteria>> FetchFullCriteriaCollection(bool trackChanges) =>
       await FindAll(trackChanges).ToListAsync();


    public async Task<Criteria?> GetCriteriaById(Guid id, bool trackChanges) =>
        await FindByCondition(x => id.Equals(x.Id), trackChanges).SingleOrDefaultAsync();
}
