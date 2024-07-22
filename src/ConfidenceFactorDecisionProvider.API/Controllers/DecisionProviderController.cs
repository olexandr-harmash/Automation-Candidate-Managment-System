using Microsoft.AspNetCore.Mvc;

namespace ConfidenceFactorDecisionProvider.API.Controllers;

[ApiController]
[Route("api/decision")]
public class DecisionProviderController
{
    private readonly DecisionProviderServices _decisionProviderServices;

    public DecisionProviderController(DecisionProviderServices decisionProviderServices)
    {
        _decisionProviderServices = decisionProviderServices;
    }

    [HttpPost]
    public async Task<IResult> SendDecisionIntention(ConfidenceMetric сonfidenceMetric)
    {
        await _decisionProviderServices.decisionProviderService.ExecuteStrategy(сonfidenceMetric);

        return TypedResults.Ok();
    }
}
