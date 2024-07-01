namespace ConfidenceFactorAssessment.API.Exceptions;

public class AssessmentNotFoundException : NotFoundException
{
    public AssessmentNotFoundException(Guid id)
        : base($"The assessment with id: {id} doesn't exist in the database.") { }

    public AssessmentNotFoundException(IEnumerable<Guid> ids)
        : base($"The assessment with ids: {ids} doesn't exist in the database.") { }
}
