namespace ConfidenceFactorDecisionProvider.API.Models;

public class ConfidenceMetric
{
    public Guid AssessmentId { get; set; }
    public IEnumerable<float> Metrics { get; set; }
}