using polymer.core.Domain;

namespace polymer.core.Querying
{
    public interface IListItemFactoryProvider
    {
        IListItemFactory<TEntity> GetListItemFactory<TEntity>() where TEntity : IEntity;
    }
}