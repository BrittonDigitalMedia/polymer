using Machine.Specifications;
using polymer.tests.redis.for_BasicPersistence.assets;
using ServiceStack.Redis;
using System;

namespace polymer.tests.redis.for_BasicPersistence
{
	public class when_saving_an_entity : given.a_redis_instance
	{
		Establish context = () =>
		{
			_entity = new FakeEntityForRedis
			{
				Key = Guid.NewGuid(),
				Id = "ids/1",
				TestDateTime = DateTime.Now,
				TestDouble = 1699D
			};
		};
		Because of = () =>
		{
			using (IRedisClient client = _manager.GetClient())
			{

				var repo = client.As<FakeEntityForRedis>();
				_entity.Id = string.Format("ids/{0}", repo.GetNextSequence());
				repo.Store(_entity);
				_returnEntity = repo.GetById(_entity.Id);

			}
		};

		It should_not_return_null = () => _returnEntity.ShouldNotBeNull();
		It should_have_proper_double_value = () => _returnEntity.TestDouble.ShouldEqual(1699D);

		protected static FakeEntityForRedis _entity;
		protected static FakeEntityForRedis _returnEntity;
	}
}