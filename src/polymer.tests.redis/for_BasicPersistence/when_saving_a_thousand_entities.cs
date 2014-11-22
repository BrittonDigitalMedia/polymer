using System;
using System.Collections.Generic;
using System.Diagnostics;
using Machine.Specifications;
using polymer.tests.redis.for_BasicPersistence.assets;
using ServiceStack.Redis;

namespace polymer.tests.redis.for_BasicPersistence
{
	public class when_saving_a_thousand_entities : given.a_redis_instance
	{
		private Establish context = () =>
		{
			_entities = new List<FakeEntityForRedis>();
			for (int i = 1; i < 1001; i++)
			{
				var entity = new FakeEntityForRedis
				{
					Key = Guid.NewGuid(),
					Id = string.Format("ids/{0}", i),
					TestDateTime = DateTime.Now,
					TestDouble = 1699D
				};
				_entities.Add(entity);
			}
		};

		Because of = () =>
		{
			using (IRedisClient client = _manager.GetClient())
			{

				var repo = client.As<FakeEntityForRedis>();
				_saveSw = Stopwatch.StartNew();
				foreach (var entity in _entities)
				{
					repo.Store(entity);
				}
				_saveSw.Stop();
				_getSw = Stopwatch.StartNew();
				_results = repo.GetAll();
				_getSw.Stop();


			}
		};

		It should_not_return_null = () => _results.ShouldNotBeNull();
		It should_return_a_thousand_entities = () => _results.Count.ShouldEqual(1000);

		private static List<FakeEntityForRedis> _entities;
		private static Stopwatch _saveSw;
		private static IList<FakeEntityForRedis> _results;
		private static Stopwatch _getSw;
	}
}