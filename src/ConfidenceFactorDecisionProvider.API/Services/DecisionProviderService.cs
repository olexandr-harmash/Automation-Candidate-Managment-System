using Microsoft.Extensions.Options;

namespace ConfidenceFactorDecisionProvider.API.Services;

public class DecisionProviderService : IDecisionProviderService
{
    private readonly IStrategyProvider _strategyProvider;
    private readonly DecisionProviderServiceOptions _options;
    private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();

    public DecisionProviderService(IStrategyProvider strategyProvider, IOptions<DecisionProviderServiceOptions> options)
    {
        _options = options.Value;
        _strategyProvider = strategyProvider;
    }

    /// <summary>
    /// Executes a strategy based on confidence metrics.
    /// </summary>
    /// <param name="confidenceMetric">Confidence metrics to execute strategy.</param>
    public Task ExecuteStrategy(ConfidenceMetric confidenceMetric)
    {
        _tokenSource.CancelAfter(_options.MaxExecutionTime);

        _ = Task.Factory.StartNew(() =>
        {
            try
            {
                var strategy = _strategyProvider.ResolveStrategy<
                    ConfidenceFactorStrategyInput, 
                    ConfidenceFactorStrategyOutput, 
                    IConfidenceFactorAssessmentStrategy
                >(_options.Algorithm);

                var decision = strategy.Execute(new (confidenceMetric.Metrics.ToArray()), _tokenSource.Token);

                // Implement event publishing logic
                // e.g., _eventBus.Publish(new DecisionCompletedEvent(...));
            }
            catch (OperationCanceledException)
            {
                // e.g., _logger.LogWarning("Operation was canceled.");
            }
            catch (Exception ex)
            {
                // e.g., _logger.LogError(ex, "An error occurred while providing decision.");
                throw new ApplicationException("An error occurred while executing the strategy.", ex);
            }
            finally
            {
                _tokenSource.Dispose();
            }
        }, _tokenSource.Token);

        return Task.CompletedTask;
    }

}
