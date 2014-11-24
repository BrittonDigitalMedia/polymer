namespace polymer.core.Querying
{
    public interface IQueryHandlerWithResult<in TSpecification, out TResult>
        where TSpecification : IMultipleResultQuerySpecification
        where TResult : IQueryResult
    {
        TResult Handle(TSpecification specification);
    }
}