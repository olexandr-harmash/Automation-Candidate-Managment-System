namespace ConfidenceFactorDecisionProvider.API.Services.Abstractions;

public class DecisionProviderServiceOptions
{
    public const string Section = "DecisionProvider";
    public string Algorithm { get; set; }
    public int MaxExecutionTime { get; set; } = 3000;
}
