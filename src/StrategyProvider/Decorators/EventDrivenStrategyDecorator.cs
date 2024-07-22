namespace StrategyProvider.Decorators;

public class EventDrivenStrategyDecorator<TIn, TOut, TSt> : IStrategy<TIn, TOut>
{
    private TSt _strategy;

    public EventDrivenStrategyDecorator(TSt strategy)
    {
        if (strategy == null)
        {
            throw new ArgumentException("The strategy cannot be null.", nameof(strategy));
        }  

        _strategy = strategy;
    }

    public TOut Execute(TIn input /*, TCtx send context data in params in future*/, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /*implement event driven pattern for start execution, end execution, fail... and so on*/
}
