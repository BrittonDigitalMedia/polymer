using polymer.core.Composition;

namespace polymer.databases.ravendb
{
	public class RavenDbDatabaseJobInitialiser : IRunAtStartUp
	{
		public void StartUp(IContainer container)
		{
			container.FindAndInjectAll<IRavenDbDatabaseJob>();
		}
	}
}