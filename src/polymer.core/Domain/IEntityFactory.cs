namespace polymer.core.Domain
{
    public interface IEntityFactory<out TEntity> where TEntity : IEntity
    {
        TEntity Create();
    }

    
}