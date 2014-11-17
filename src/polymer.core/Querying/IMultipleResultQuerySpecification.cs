namespace mosaic.core.contracts.Querying
{
    public interface IMultipleResultQuerySpecification
    {
        int RequestedPage { get; set; }
        int RecordsPerPage { get; set; }
    }
}