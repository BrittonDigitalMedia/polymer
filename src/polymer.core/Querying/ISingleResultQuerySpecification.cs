namespace mosaic.core.contracts.Querying
{
    public interface ISingleResultQuerySpecification
    {
        bool ThrowErrorOnMultipleResults { get; set; }
    }
}