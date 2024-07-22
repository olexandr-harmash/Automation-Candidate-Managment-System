namespace StrategyProvider.Abstractions;

public interface IStrategy<TIn, TOut>
{
    TOut Execute(TIn input, CancellationToken cancellationToken);
}