using AutoMapper;
using ConfidenceFactorAssessment.API.Repository;

namespace ConfidenceFactorAssessment.API.Services;

public class CriteriaService : ICriteriaService
{
    private readonly IMapper _assessmentMapper;
    private readonly AssessmentRepositoryManager _assessmentRepositoryManager;

    public CriteriaService(AssessmentRepositoryManager assessmentRepositoryManager, IMapper assessmentMapper)
    {
        _assessmentRepositoryManager = assessmentRepositoryManager;
        _assessmentMapper = assessmentMapper;
    }

    public async Task<IEnumerable<CriteriaDto>> CreateCriteriaCollection(IEnumerable<CriteriaDtoForCreate> criteriaCollection, bool trackChanges)
    {
        var criteriaCollectioeEntity = _assessmentMapper.Map<IEnumerable<Criteria>>(criteriaCollection);

        _assessmentRepositoryManager.Criteria.CreateCriteriaCollection(criteriaCollectioeEntity, trackChanges);

        await _assessmentRepositoryManager.SaveChangesAsync();

        var criteriaCollectioeToReturn = _assessmentMapper.Map<IEnumerable<CriteriaDto>>(criteriaCollectioeEntity);

        return criteriaCollectioeToReturn;
    }

    public async Task<IEnumerable<CriteriaDto>> FetchFullCriteriaCollection(bool trackChanges)
    {
        var criteriaCollectionEntity = await _assessmentRepositoryManager.Criteria.FetchFullCriteriaCollection(trackChanges);

        var criteriaCollectionToReturn = _assessmentMapper.Map<IEnumerable<CriteriaDto>>(criteriaCollectionEntity);

        return criteriaCollectionToReturn;
    }

    public async Task<CriteriaDto> GetCriteriaById(Guid id, bool trackChanges)
    {
        var criteriaEntity = await _assessmentRepositoryManager.Criteria.GetCriteriaById(id, trackChanges);

        if (criteriaEntity == null)
        {
            throw new CriteriaNotFoundException(id);
        }

        var criteriaToReturn = _assessmentMapper.Map<CriteriaDto>(criteriaEntity);

        return criteriaToReturn;
    }
}
