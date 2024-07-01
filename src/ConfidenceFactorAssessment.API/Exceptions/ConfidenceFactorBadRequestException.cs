namespace ConfidenceFactorAssessment.API.Exceptions;

public class ConfidenceFactorBadRequestException : BadRequestException
{
    public ConfidenceFactorBadRequestException(Guid assesmentId, Guid criteriaId)
       : base($"The relation between assesment and criteria with: assesment id - {assesmentId} and criteria id - {criteriaId} already exist in the database.") { }
}
