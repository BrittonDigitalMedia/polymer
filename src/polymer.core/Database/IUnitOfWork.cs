using polymer.core.Domain;
using System;
using System.Collections.Generic;

namespace polymer.core.Database
{
	public interface IUnitOfWork : IDisposable
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
		TEntity Get<TEntity>(Guid key) where TEntity : IEntity;
		void Store(dynamic entity);
		void Commit();
	}
}