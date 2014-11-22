using ServiceStack;

namespace polymer.tests.servicestack.for_ServerSent_Events.assets
{
	public class FakeSseService : Service
	{
		private readonly IServerEvents _serverEvents;

		public FakeSseService(IServerEvents serverEvents)
		{
			_serverEvents = serverEvents;
			_serverEvents.Start();
		}

		public FakeSseResponse Any(FakeSseRequest sseRequest)
		{
			_serverEvents.NotifyChannel("test", null, "testing");
			return new FakeSseResponse { TestProperty = sseRequest.TestProperty };
		}
	}
}