using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace StrategyProvider;

public static class StrategyProviderDependencyInjection
{
    public static IStrategyProviderBuilder AddStrategyProvider(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IStrategyProvider, StrategyProvider>();

        return new StrategyProviderBuilder(builder.Services);
    }

    private class StrategyProviderBuilder(IServiceCollection services) : IStrategyProviderBuilder
    {
        public IServiceCollection Services => services;
    }
}
