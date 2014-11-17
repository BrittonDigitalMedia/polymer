namespace mosaic.core.contracts.Querying
{
    public interface IQueryHandlerWithResults<in TSpecification, out TResult>
        where TSpecification : IMultipleResultQuerySpecification
        where TResult : IQueryResults
    {
        TResult Handle(TSpecification specification);
    }
}