using AutoMapper;
using ConfidenceFactorAssessment.API.Repository;

namespace ConfidenceFactorAssessment.API.Services;

public class ConfidenceFactorService : IConfidenceFactorService
{
    private readonly IMapper _assessmentMapper;
    private readonly AssessmentRepositoryManager _assessmentRepositoryManager;

    public ConfidenceFactorService(AssessmentRepositoryManager estimationRepositoryManager, IMapper estimationMapper)
    {
        _assessmentRepositoryManager = estimationRepositoryManager;
        _assessmentMapper = estimationMapper;
    }

    public async Task<ConfidenceFactorDto> CreateConfidenceFactor(Guid assessmentId, Guid criteriaId, ConfidenceFactorDtoForCreate assessment, bool trackChanges)
    {
        await GetAssessmentAndCheckIfExists(assessmentId, trackChanges);

        await GetCriteriaAndCheckIfExists(criteriaId, trackChanges);

        var confidenceFactorEntity = await _assessmentRepositoryManager.ConfidenceFactor.GetConfidenceFactor(assessmentId, criteriaId, trackChanges);

        if (confidenceFactorEntity != null)
        {
            throw new ConfidenceFactorBadRequestException(assessmentId, criteriaId);
        }

        confidenceFactorEntity = _assessmentMapper.Map<ConfidenceFactor>(assessment);

        _assessmentRepositoryManager.ConfidenceFactor.CreateConfidenceFactor(assessmentId, criteriaId, confidenceFactorEntity);

        await _assessmentRepositoryManager.SaveChangesAsync();

        var confidenceFactorToReturn = _assessmentMapper.Map<ConfidenceFactorDto>(confidenceFactorEntity);

        return confidenceFactorToReturn;
    }

    public async Task DeleteConfidenceFactor(Guid assessmentId, Guid criteriaId, bool trackChanges)
    {
        await GetAssessmentAndCheckIfExists(assessmentId, trackChanges);

        await GetCriteriaAndCheckIfExists(criteriaId, trackChanges);

        var confidenceFactorEntity = await GetConfidenceFactorAndCheckIfExists(assessmentId, criteriaId, trackChanges);

        _assessmentRepositoryManager.ConfidenceFactor.DeleteConfidenceFactor(confidenceFactorEntity);

        await _assessmentRepositoryManager.SaveChangesAsync();
    }

    public async Task<IEnumerable<ConfidenceFactorDto>> FetchConfidenceFactor(Guid assessmentId, IEnumerable<Guid> criteriaIds, bool trackChanges)
    {
        await GetAssessmentAndCheckIfExists(assessmentId, trackChanges);

        var confidenceFactorCollectionEntity = await _assessmentRepositoryManager.ConfidenceFactor.FetchConfidenceFactor(assessmentId, criteriaIds, trackChanges);

        if (confidenceFactorCollectionEntity.Count() != criteriaIds.Count())
        {
            throw new ConfidenceFactorNotFoundException(assessmentId, criteriaIds);
        }

        var confidenceFactorCollectionToReturn = _assessmentMapper.Map<IEnumerable<ConfidenceFactorDto>>(confidenceFactorCollectionEntity);

        return confidenceFactorCollectionToReturn;
    }

    public async Task<ConfidenceFactorDto> GetConfidenceFactor(Guid assessmentId, Guid criteriaId, bool trackChanges)
    {
        await GetAssessmentAndCheckIfExists(assessmentId, trackChanges);

        await GetCriteriaAndCheckIfExists(criteriaId, trackChanges);

        var confidenceFactorEntity = await GetConfidenceFactorAndCheckIfExists(assessmentId, criteriaId, trackChanges);

        var confidenceFactorForReturn = _assessmentMapper.Map<ConfidenceFactorDto>(confidenceFactorEntity);

        return confidenceFactorForReturn;
    }

    public async Task UpdateConfidenceFactor(Guid assessmentId, Guid criteriaId, ConfidenceFactorDtoForUpdate confidenceFactor, bool trackChanges)
    {
        await GetAssessmentAndCheckIfExists(assessmentId, trackChanges);

        await GetCriteriaAndCheckIfExists(criteriaId, trackChanges);

        var confidenceFactorEntity = await GetConfidenceFactorAndCheckIfExists(assessmentId, criteriaId, trackChanges);

        _assessmentMapper.Map(confidenceFactor, confidenceFactorEntity);

        await _assessmentRepositoryManager.SaveChangesAsync();
    }

    private async Task<ConfidenceFactor> GetConfidenceFactorAndCheckIfExists(Guid assessmentId, Guid criteriaId, bool trackChanges)
    {
        var confidenceFactorEntity = await _assessmentRepositoryManager.ConfidenceFactor.GetConfidenceFactor(assessmentId, criteriaId, trackChanges);

        if (confidenceFactorEntity == null)
        {
            throw new ConfidenceFactorNotFoundException(assessmentId, criteriaId);
        }

        return confidenceFactorEntity;
    }

    private async Task<Assessment> GetAssessmentAndCheckIfExists(Guid assessmentId, bool trackChanges)
    {
        var assessmentEntity = await _assessmentRepositoryManager.Assessment.GetAssessmentById(assessmentId, trackChanges);

        if (assessmentEntity == null)
        {
            throw new AssessmentNotFoundException(assessmentId);
        }

        return assessmentEntity;
    }

    private async Task<Criteria> GetCriteriaAndCheckIfExists(Guid criteriaId, bool trackChanges)
    {
        var criteriaEntity = await _assessmentRepositoryManager.Criteria.GetCriteriaById(criteriaId, trackChanges);

        if (criteriaEntity == null)
        {
            throw new CriteriaNotFoundException(criteriaId);
        }

        return criteriaEntity;
    }
}
