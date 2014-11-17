using System;

namespace polymer.core.Database
{
	public interface IDatabaseContext : IDisposable
	{
		IUnitOfWork NewSession(string databaseName);
	}
}