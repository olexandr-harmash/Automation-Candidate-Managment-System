namespace StrategyProvider.Abstractions;

public interface IStrategyProvider
{
    EventDrivenStrategyDecorator<TIn, TOut, TSt> ResolveStrategy<TIn, TOut, TSt>(string key)
        where TSt : IStrategy<TIn, TOut>;
}
