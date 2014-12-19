using System.Collections;
using System.Collections.Generic;
using polymer.core.Domain;

namespace polymer.core.Persistence
{
	public interface IEntityPersistenceManager<TEntity> where TEntity : IEntity
	{
		void Store(TEntity entity) ;
		void Store(params TEntity[] entities) ;
		void Store(IEnumerable<TEntity> entities) ;
		void Delete(string id) ;
		void Delete(params string[] ids) ;
		void Delete(IEnumerable<string> ids) ;
		TEntity[] Get(params string[] ids) ;
		TEntity[] Get(IEnumerable<string> ids) ;
		TEntity Get(string id) ;
	}
}