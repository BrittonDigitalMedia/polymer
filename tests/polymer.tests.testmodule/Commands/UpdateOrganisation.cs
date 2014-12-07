using polymer.core.Commanding;
using polymer.tests.testmodule.DomainObjects;
using ServiceStack;

namespace polymer.tests.testmodule.Commands
{
	[Route("/organisations", "POST", Summary = "updates an existing organisations")]
	public class UpdateOrganisation : ICommand<UpdateOrganisationResult>, IReturn<UpdateOrganisationResult>
	{
		public Organisation Organisation { get; set; }
	}

	public class UpdateOrganisationResult : ICommandResult
	{

	}
}