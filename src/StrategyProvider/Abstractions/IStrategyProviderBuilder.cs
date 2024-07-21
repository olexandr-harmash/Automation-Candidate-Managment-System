using Microsoft.Extensions.DependencyInjection;

namespace StrategyProvider.Abstractions;

public interface IStrategyProviderBuilder
{
    public IServiceCollection Services { get; }
}
