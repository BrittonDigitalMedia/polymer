using System.Collections.Generic;

namespace polymer.api.servicestack
{
	public class HostConfiguration : IHostConfiguration
	{
		private Dictionary<string, object> config;

		public HostConfiguration()
		{
			config = new Dictionary<string, object>();
		}
		public TType Get<TType>(string key)
		{
			throw new System.NotImplementedException();
		}

		public void Set(string key, object value)
		{
			throw new System.NotImplementedException();
		}
	}
}