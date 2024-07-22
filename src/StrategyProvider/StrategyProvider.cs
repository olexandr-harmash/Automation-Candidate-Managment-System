using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

namespace StrategyProvider;

public class StrategyProvider(
    IServiceProvider serviceProvider, 
    IOptions<StrategyProviderInfo> info) 
    : IStrategyProvider
{
    private readonly StrategyProviderInfo _info = info.Value;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public EventDrivenStrategyDecorator<TIn, TOut, TSt> ResolveStrategy<TIn, TOut, TSt>(string key) 
        where TSt : IStrategy<TIn, TOut>
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("The key cannot be null or whitespace.", nameof(key));
        }

        if (!_info.StrategyTypes.TryGetValue(key, out var strategyType))
        {
            throw new StrategyNotFoundException($"Strategy not found for key: {key}");
        }

        var strategy = _serviceProvider.GetKeyedService<TSt>(strategyType);

        if (strategy == null)
        {
            throw new InvalidOperationException($"Service of type {strategyType} not found.");
        }  

        return new EventDrivenStrategyDecorator<TIn, TOut, TSt>(strategy);
    }
}