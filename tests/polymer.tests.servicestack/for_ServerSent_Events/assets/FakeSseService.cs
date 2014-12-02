using ServiceStack;

namespace polymer.tests.servicestack.for_ServerSent_Events.assets
{
	public class FakeSseService : Service
	{
		private readonly IServerEvents _serverEvents;

		public FakeSseService(IServerEvents serverEvents)
		{
			_serverEvents = serverEvents;
		}

		public FakeSseResponse Any(FakeSseRequest sseRequest)
		{
			
			_serverEvents.NotifyChannel("test", "testMessage");
			return new FakeSseResponse { TestProperty = sseRequest.TestProperty };
		}
	}
}