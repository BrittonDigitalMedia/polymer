using polymer.core.Domain;

namespace polymer.core.Querying
{
    public interface IListItemFactory<TEntity> where TEntity : IEntity
    {
        ListItem Create(string id);
    }
}