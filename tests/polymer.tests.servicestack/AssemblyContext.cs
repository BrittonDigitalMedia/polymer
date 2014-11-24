using System;
using Machine.Specifications;
using RedisIntegration;

namespace polymer.tests.servicestack
{
	public class AssemblyContext : IAssemblyContext
	{
		private Connection _connectionInfo;

		public void OnAssemblyStart()
		{
			_connectionInfo = HostManager.RunInstance(1235);
		}

		public void OnAssemblyComplete()
		{
			_connectionInfo = null;
			GC.Collect();
		}
	}
}