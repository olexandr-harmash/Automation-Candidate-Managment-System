namespace ConfidenceFactorDecisionProvider.API.Strategies.Abstractions;

public class ConfidenceFactorStrategyInput(float[] metrics)
{
	public float[] Metrics { get; set; } = metrics;
}