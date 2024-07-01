namespace ConfidenceFactorAssessment.API.Repository.Abstractions;

public interface ICriteriaRepository
{
    Task<Criteria?> GetCriteriaById(Guid id, bool trackChanges);
    Task<IEnumerable<Criteria>> FetchFullCriteriaCollection(bool trackChanges);
    void CreateCriteriaCollection(IEnumerable<Criteria> criteriaCollection, bool trackChanges);
}
