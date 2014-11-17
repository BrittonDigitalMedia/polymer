using System.Collections.Generic;
using polymer.core.Domain;

namespace polymer.core.Persistence
{
    public interface IPersistenceManager
    {
        void Store<TEntity>(TEntity entity) where TEntity : IEntity;
        void Store<TEntity>(params TEntity[] entities) where TEntity : IEntity;
        void Store<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity;
        void Delete<TEntity>(string id) where TEntity : IEntity;
        void Delete<TEntity>(params string[] ids) where TEntity : IEntity;
        void Delete<TEntity>(IEnumerable<string> ids) where TEntity : IEntity;
        TEntity[] Get<TEntity>(params string[] ids) where TEntity : IEntity;
        TEntity[] Get<TEntity>(IEnumerable<string> ids) where TEntity : IEntity;
        TEntity Get<TEntity>(string id) where TEntity : IEntity;
    }
}