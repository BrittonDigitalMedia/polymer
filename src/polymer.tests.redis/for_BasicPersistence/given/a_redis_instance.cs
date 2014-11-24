using System;
using System.IO;
using Machine.Specifications;
using ServiceStack.Redis;

namespace polymer.tests.redis.for_BasicPersistence.given
{

	public class a_redis_instance
	{
		Establish context = () =>
		{
			
			_manager = new BasicRedisClientManager("localhost:1235");
		};

		protected static BasicRedisClientManager _manager;

	}
}