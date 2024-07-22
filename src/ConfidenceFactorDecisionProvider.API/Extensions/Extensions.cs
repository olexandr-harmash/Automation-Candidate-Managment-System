using  StrategyProvider.Extensions;
using ConfidenceFactorDecisionProvider.API.Strategies;
using ConfidenceFactorDecisionProvider.API.Controllers;

namespace ConfidenceFactorDecisionProvider.API.Extensions;

public static class Extensions
{
    public static IHostApplicationBuilder AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Services.AddScoped<DecisionProviderServices>();

        builder.AddStrategyProvider()
            .AddDecisionStrategy<IConfidenceFactorAssessmentStrategy, ConfidenceFactorAssessmentStrategyStub>();

        builder.Services.Configure<DecisionProviderServiceOptions>(
            builder.Configuration.GetSection(DecisionProviderServiceOptions.Section)
        );

        builder.Services.AddScoped<DecisionProviderService>();

        return builder;
    }
}