using Funq;
using NMoneys;
using NMoneys.Serialization.Service_Stack;
using NodaTime;
using NodaTime.Serialization.ServiceStackText;
using ServiceStack;
using System.Reflection;
using ServiceStack.Text;

namespace polymer.api.servicestack
{
	public class PolymerAppHost : AppHostHttpListenerSmartPoolBase
	{
		public PolymerAppHost(string serviceName, params Assembly[] assembliesWithServices)
			: base(serviceName, assembliesWithServices)
		{
		}

		public PolymerAppHost(string serviceName, int poolSize, params Assembly[] assembliesWithServices)
			: base(serviceName, poolSize, assembliesWithServices)
		{
		}

		public PolymerAppHost(string serviceName, string handlerPath, params Assembly[] assembliesWithServices)
			: base(serviceName, handlerPath, assembliesWithServices)
		{
		}

		public PolymerAppHost(string serviceName, string handlerPath, int poolSize, params Assembly[] assembliesWithServices)
			: base(serviceName, handlerPath, poolSize, assembliesWithServices)
		{
		}

		public override void Configure(Container container)
		{
			SetupNodaTime();
			SetUpNMoney();
		}

		private static void SetupNodaTime()
		{
			DateTimeZoneProviders.Tzdb.CreateDefaultSerializersForNodaTime().ConfigureSerializersForNodaTime();
		}

		private static void SetUpNMoney()
		{
			JsConfig<Money>.DeSerializeFn = DefaultMoneySerializer.Deserialize;
			JsConfig<Money>.SerializeFn = DefaultMoneySerializer.Serialize;
		}
	}
}