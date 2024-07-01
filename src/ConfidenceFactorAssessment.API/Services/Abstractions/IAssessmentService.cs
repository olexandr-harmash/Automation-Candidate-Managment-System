namespace ConfidenceFactorAssessment.API.Services.Abstractions;

public interface IAssessmentService
{
    Task<AssessmentDto> GetAssessmentById(Guid id, bool trackChanges);
    Task<AssessmentDto> CreateAssessment(AssessmentDtoForCreate assessment);
    Task UpdateAssessment(Guid id, AssessmentDtoForUpdate assessment, bool trackChanges);
    Task DeleteAssessment(Guid id, bool trackChanges);
    //Task<Qualification> MatchAssessmentToPattern(Guid assessmentId, string strategy, bool trackChanges);
}
