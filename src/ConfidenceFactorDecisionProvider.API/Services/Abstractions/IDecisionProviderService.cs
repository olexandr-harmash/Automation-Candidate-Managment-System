namespace ConfidenceFactorDecisionProvider.API.Services.Abstractions;

public interface IDecisionProviderService
{
    Task ExecuteStrategy(ConfidenceMetric confidenceMetric);
}