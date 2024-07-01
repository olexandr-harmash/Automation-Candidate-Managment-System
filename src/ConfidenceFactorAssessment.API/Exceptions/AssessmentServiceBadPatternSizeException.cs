namespace ConfidenceFactorAssessment.API.Exceptions;

public class AssessmentServiceBadPatternSizeException : Exception
{
    public AssessmentServiceBadPatternSizeException() : base($"Failed match assessment to pattern due to criterias mismatch.") { }
}
