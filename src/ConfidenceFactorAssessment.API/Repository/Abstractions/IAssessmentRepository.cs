namespace ConfidenceFactorAssessment.API.Repository.Abstractions;

public interface IAssessmentRepository
{
    Task<Assessment?> GetAssessmentById(Guid assessmentId, bool trackChanges);
    void CreateAssessment(Assessment assessment);
    void DeleteAssessment(Assessment assessment);
}
