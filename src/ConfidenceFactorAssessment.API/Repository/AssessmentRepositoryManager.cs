using ConfidenceFactorAssessment.API.Repository.Abstractions;

namespace ConfidenceFactorAssessment.API.Repository;

public class AssessmentRepositoryManager
{
    private readonly ConfidenceFactorAssessmentContext _confidenceFactorAssessmentContext;
    private readonly IAssessmentRepository _assessmentRepository;
    private readonly ICriteriaRepository _criteriaRepository;
    private readonly IConfidenceFactorRepository _confidenceFactorRepository;

    public AssessmentRepositoryManager(
        IAssessmentRepository assessmentRepository,
        ICriteriaRepository criteriaRepository,
        IConfidenceFactorRepository confidenceFactorRepository,
        ConfidenceFactorAssessmentContext confidenceFactorAssessmentContext)
    {
        _assessmentRepository = assessmentRepository;
        _confidenceFactorAssessmentContext = confidenceFactorAssessmentContext;
        _criteriaRepository = criteriaRepository;
        _confidenceFactorRepository = confidenceFactorRepository;
    }

    public IAssessmentRepository Assessment => _assessmentRepository;
    public ICriteriaRepository Criteria => _criteriaRepository;
    public IConfidenceFactorRepository ConfidenceFactor => _confidenceFactorRepository;

    public Task SaveChangesAsync() => _confidenceFactorAssessmentContext.SaveChangesAsync();
}
