using System;
using System.Collections.Generic;
using System.Linq;
using polymer.core.Database;
using polymer.core.Domain;
using Raven.Client;

namespace polymer.databases.ravendb
{
	public class RavenDbUnitOfWork : IUnitOfWork
	{
		private IDocumentSession _session;

		internal RavenDbUnitOfWork(IDocumentSession session)
		{
			_session = session;
		}

		public void Dispose()
		{
			_session.Dispose();
		}

		public void Store<TEntity>(TEntity entity) where TEntity : IEntity
		{
			_session.Store(entity);
		}

		public void Store<TEntity>(params TEntity[] entities) where TEntity : IEntity
		{
			_session.Store(entities);
		}

		public void Store<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity
		{
			_session.Store(entities);
		}

		public void Delete<TEntity>(string id) where TEntity : IEntity
		{
			var entity = _session.Load<TEntity>(id);
			_session.Delete(entity);
		}

		public void Delete<TEntity>(params string[] ids) where TEntity : IEntity
		{
			foreach (var id in ids)
			{
				Delete<TEntity>(id);
			}
		}

		public void Delete<TEntity>(IEnumerable<string> ids) where TEntity : IEntity
		{
			foreach (var id in ids)
			{
				Delete<TEntity>(id);
			}
		}

		public TEntity[] Get<TEntity>(params string[] ids) where TEntity : IEntity
		{
			return _session.Load<TEntity>(ids);
		}

		public TEntity[] Get<TEntity>(IEnumerable<string> ids) where TEntity : IEntity
		{
			return _session.Load<TEntity>(ids);
		}

		public TEntity Get<TEntity>(string id) where TEntity : IEntity
		{
			return _session.Load<TEntity>(id);
		}

		public TEntity Get<TEntity>(Guid key) where TEntity : IEntity
		{
			return _session.Query<TEntity>().FirstOrDefault(x => x.Key == key);
		}

		public void Store(dynamic entity)
		{
			_session.Store(entity);
		}

		public void Commit()
		{
			_session.SaveChanges();
		}
	}
}