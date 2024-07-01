namespace ConfidenceFactorAssessment.API.Model;

public class Assessment
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public string CreatedBy { get; set; }
    public IEnumerable<ConfidenceFactor> ConfidenceFactors { get; set; }
}
