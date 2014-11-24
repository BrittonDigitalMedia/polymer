namespace polymer.core.Querying
{
    public interface IMultipleResultQuerySpecification
    {
        int RequestedPage { get; set; }
        int RecordsPerPage { get; set; }
    }
}