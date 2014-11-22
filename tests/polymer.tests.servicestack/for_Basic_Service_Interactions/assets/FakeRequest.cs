using ServiceStack;

namespace polymer.tests.servicestack.for_Basic_Service_Interactions.assets
{
	[Route("/test")]
	public class FakeRequest : IReturn<FakeResponse>
	{
		public string TestProperty { get; set; }
	}
}