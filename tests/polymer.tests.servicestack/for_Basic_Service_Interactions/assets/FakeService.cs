using ServiceStack;

namespace polymer.tests.servicestack.for_Basic_Service_Interactions.assets
{
	public class FakeService : Service
	{
		public FakeResponse Any(FakeRequest request)
		{
			return new FakeResponse { TestProperty = request.TestProperty };
		}
	}
}