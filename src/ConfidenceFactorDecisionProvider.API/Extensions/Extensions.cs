using  StrategyProvider.Extensions;
using ConfidenceFactorDecisionProvider.API.Strategies;

namespace ConfidenceFactorDecisionProvider.API.Extensions;

public static class Extensions
{
    public static IHostApplicationBuilder AddDecisionProvider(this IHostApplicationBuilder builder)
    {
        builder.AddStrategyProvider()
            .AddDecisionStrategy<IConfidenceFactorAssessmentStrategy, ConfidenceFactorAssessmentStrategyStub>();

        builder.Services.Configure<DecisionProviderServiceOptions>(
            builder.Configuration.GetSection(DecisionProviderServiceOptions.Section)
        );

        builder.Services.AddScoped<IDecisionProviderService>();

        return builder;
    }
}