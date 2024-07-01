using System.Text.Json.Serialization;

namespace ConfidenceFactorAssessment.API.Model;

public class ConfidenceFactor
{
    public Guid Id { get; set; }
    public double Value {  get; set; }
    public Guid CriteriaId { get; set; }
    public Guid AssessmentId { get; set; }

    [JsonIgnore]
    public Criteria Criteria { get; set;}

    [JsonIgnore]
    public Assessment Assessment { get; set; }
}
