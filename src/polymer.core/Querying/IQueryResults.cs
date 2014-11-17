namespace mosaic.core.contracts.Querying
{
    public interface IQueryResults
    {
        int ResultsReturned { get; set; }
        int TotalResults { get; set; }
        int TotalPages { get; set; }
        int PageNumber { get; set; }
    }
}