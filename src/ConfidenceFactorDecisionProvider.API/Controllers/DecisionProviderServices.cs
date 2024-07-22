namespace ConfidenceFactorDecisionProvider.API.Controllers;

public class DecisionProviderServices(
    ILogger<DecisionProviderServices> logger,
    DecisionProviderService decisionProviderService)
{
    public readonly ILogger<DecisionProviderServices>  logger = logger;
    public readonly DecisionProviderService decisionProviderService = decisionProviderService;
}
