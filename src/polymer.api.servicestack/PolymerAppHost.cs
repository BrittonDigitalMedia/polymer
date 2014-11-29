using Funq;
using NMoneys;
using NodaTime;
using NodaTime.Serialization.ServiceStackText;
using polymer.api.servicestack.Infrastructure.Serialization;
using ServiceStack;
using ServiceStack.Configuration;
using ServiceStack.Redis;
using ServiceStack.Text;
using System;
using System.Reflection;

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

			Plugins.Add(new ServerEventsFeature());
			SetupRedis(container);

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

		private void SetupRedis(Container container)
		{
			var appSettings = new AppSettings();
			var connectionString = string.Format("{0}:{1}", appSettings.Get("Redis.Host"), appSettings.Get("Redis.Port"));
			container.Register<IRedisClientsManager>(c => new RedisManagerPool(connectionString));
			var clientsManager = container.Resolve<IRedisClientsManager>();

			using (var redis = clientsManager.GetClient())
			{
				try
				{
					redis.Set("test", true);
					container.Register<IServerEvents>(c => new RedisServerEvents(container.Resolve<IRedisClientsManager>()));
				}
				catch (Exception)
				{
					container.Register<IServerEvents>(c => new MemoryServerEvents());
				}
				finally
				{
					container.Resolve<IServerEvents>().Start();
				}

			}
		}
	}
}