namespace ConfidenceFactorAssessment.API.Exceptions;

public class ConfidenceFactorNotFoundException : NotFoundException
{
    public ConfidenceFactorNotFoundException(Guid assessmentId, Guid criteriaId)
        : base($"The relation between assessment and criteria with: assessment id - {assessmentId} and criteria id - {criteriaId} doesn't exist in the database.") { }

    public ConfidenceFactorNotFoundException(Guid assessmentId, IEnumerable<Guid> criteriaIds)
        : base($"The relation between assessment and criteria with: assessment id - {assessmentId} and criteria ids {criteriaIds} doesn't exist in the database.") { }
}
