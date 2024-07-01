using AutoMapper;
using ConfidenceFactorAssessment.API.Repository;

namespace ConfidenceFactorAssessment.API.Services;

public class AssessmentService : IAssessmentService
{
    private readonly IMapper _assesmentMapper;
    //private readonly INetworkContext _networkContext;
    private readonly AssessmentRepositoryManager _assesmentRepositoryManager;

    public AssessmentService(AssessmentRepositoryManager assesmentRepositoryManager, IMapper assesmentMapper/*, INetworkContext networkContext*/)
    {
        _assesmentRepositoryManager = assesmentRepositoryManager;
        _assesmentMapper = assesmentMapper;
        //_networkContext = networkContext;
    }

    public async Task<AssessmentDto> CreateAssessment(AssessmentDtoForCreate assessment)
    {
        var assessmentEntity = _assesmentMapper.Map<Assessment>(assessment);

        _assesmentRepositoryManager.Assessment.CreateAssessment(assessmentEntity);

        await _assesmentRepositoryManager.SaveChangesAsync();

        var assessmentToReturn = _assesmentMapper.Map<AssessmentDto>(assessmentEntity);

        return assessmentToReturn;
    }

    public async Task DeleteAssessment(Guid id, bool trackChanges)
    {
        var assessmentEntity = await GetAssessmentAndCheckIfExists(id, trackChanges);

        _assesmentRepositoryManager.Assessment.DeleteAssessment(assessmentEntity);

        await _assesmentRepositoryManager.SaveChangesAsync();
    }

    public async Task<AssessmentDto> GetAssessmentById(Guid id, bool trackChanges)
    {
        var assessmentEntity = await GetAssessmentAndCheckIfExists(id, trackChanges);

        var assessmentForReturn = _assesmentMapper.Map<AssessmentDto>(assessmentEntity);

        return assessmentForReturn;
    }

    public async Task UpdateAssessment(Guid id, AssessmentDtoForUpdate assessment, bool trackChanges)
    {
        var assessmentEntity = await GetAssessmentAndCheckIfExists(id, trackChanges);

        _assesmentMapper.Map(assessment, assessmentEntity);

        await _assesmentRepositoryManager.SaveChangesAsync();
    }

    private async Task<Assessment> GetAssessmentAndCheckIfExists(Guid id, bool trackChanges)
    {
        var assessmentEntity = await _assesmentRepositoryManager.Assessment.GetAssessmentById(id, trackChanges);

        if (assessmentEntity is null)
        {
            throw new AssessmentNotFoundException(id);
        }

        return assessmentEntity;
    }
}
