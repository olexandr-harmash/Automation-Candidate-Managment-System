namespace ConfidenceFactorAssessment.API.Controllers;

public class AssessmentServices(
    ILogger<AssessmentController> logger,
    AssessmentServiceManager assessmentServiceManager)
{
    public readonly ILogger<AssessmentController>  logger = logger;
    public readonly AssessmentServiceManager assessmentServiceManager = assessmentServiceManager;
}
