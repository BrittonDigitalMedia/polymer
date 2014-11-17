using mosaic.core.contracts.Domain;

namespace mosaic.core.contracts.Querying
{
    public interface IListItemFactory<TEntity> where TEntity : IEntity
    {
        ListItem Create(string id);
    }
}