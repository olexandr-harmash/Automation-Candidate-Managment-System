using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace StrategyProvider.Extensions;

public static class StrategyProviderExtensions
{
    public static IStrategyProviderBuilder AddDecisionStrategy<I, T>(this IStrategyProviderBuilder builder)
            where I : class
            where T : class, I
    {
        builder.Services.AddKeyedSingleton<I, T>(typeof(T));

        builder.Services.Configure<StrategyProviderInfo>(o => {
            o.StrategyTypes[typeof(T).Name] = typeof(T);       
        });

        return builder;
    }
}
