namespace ConfidenceFactorAssessment.API.Exceptions;

public class AssessmentServiceBadPatternSetupException : Exception
{
    public AssessmentServiceBadPatternSetupException(string rootPath) : base($"Failed to load or validate patterns from {rootPath}.") { }
}
