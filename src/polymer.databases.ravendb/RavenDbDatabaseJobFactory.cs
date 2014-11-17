using polymer.core.Composition;
using polymer.core.Database;

namespace polymer.databases.ravendb
{
	public class RavenDbDatabaseJobFactory : IDatabaseJobFactory
	{
		private readonly IContainer _container;

		public RavenDbDatabaseJobFactory(IContainer container)
		{
			_container = container;
		}

		public TDatabaseJob Create<TDatabaseJob>() where TDatabaseJob : class, IDatabaseJob
		{
			return _container.GetInstance<TDatabaseJob>();
		}
	}
}