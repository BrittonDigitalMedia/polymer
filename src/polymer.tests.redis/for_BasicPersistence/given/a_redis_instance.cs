using System;
using System.IO;
using Machine.Specifications;
using RedisIntegration;
using ServiceStack.Redis;

namespace polymer.tests.redis.for_BasicPersistence.given
{

	public class a_redis_instance
	{
		Establish context = () =>
		{
			
			_manager = new BasicRedisClientManager("localhost:1235");
		};

		private static Connection _connectionInfo;
		protected static BasicRedisClientManager _manager;

	}
}