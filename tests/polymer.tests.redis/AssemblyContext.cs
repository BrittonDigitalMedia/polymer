using Machine.Specifications;
using RedisIntegration;
using System;

namespace polymer.tests.redis
{
	public class AssemblyContext : IAssemblyContext
	{
		private Connection _connectionInfo;

		public void OnAssemblyStart()
		{
			_connectionInfo = RedisIntegration.HostManager.RunInstance(1235);
		}

		public void OnAssemblyComplete()
		{
			_connectionInfo = null;
			GC.Collect();
		}
	}
}