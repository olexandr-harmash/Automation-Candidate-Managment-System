namespace ConfidenceFactorAssessment.API.Services.Abstractions;

public interface ICriteriaService
{
    Task<CriteriaDto> GetCriteriaById(Guid id, bool trackChanges);
    Task<IEnumerable<CriteriaDto>> FetchFullCriteriaCollection(bool trackChanges);
    Task<IEnumerable<CriteriaDto>> CreateCriteriaCollection(IEnumerable<CriteriaDtoForCreate> criteriaCollection, bool trackChanges);
}
