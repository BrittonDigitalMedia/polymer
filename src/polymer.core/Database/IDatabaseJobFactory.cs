namespace polymer.core.Database
{
	public interface IDatabaseJobFactory
	{
		TDatabaseJob Create<TDatabaseJob>() where TDatabaseJob : class, IDatabaseJob;
	}
}