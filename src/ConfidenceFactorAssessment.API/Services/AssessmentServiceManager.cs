using ConfidenceFactorAssessment.API.Services.Abstractions;

namespace ConfidenceFactorAssessment.API.Services;

public class AssessmentServiceManager
{
    private readonly IAssessmentService _assessmentService;
    private readonly ICriteriaService _criteriaService;
    private readonly IConfidenceFactorService _confidenceFactorService;

    public AssessmentServiceManager(
        IAssessmentService assessmentService, 
        ICriteriaService criteriaService,
        IConfidenceFactorService confidenceFactorService)
    {
        _assessmentService = assessmentService;
        _criteriaService = criteriaService;
        _confidenceFactorService = confidenceFactorService;
    }

    public IAssessmentService Assessment => _assessmentService;
    public ICriteriaService Criteria => _criteriaService;
    public IConfidenceFactorService ConfidenceFactor => _confidenceFactorService;
}
