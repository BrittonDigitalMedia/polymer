using mosaic.core.contracts.Domain;

namespace mosaic.core.contracts.Querying
{
    public interface IListItemFactoryProvider
    {
        IListItemFactory<TEntity> GetListItemFactory<TEntity>() where TEntity : IEntity;
    }
}