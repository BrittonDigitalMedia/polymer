using polymer.core.Commanding;
using ServiceStack;
using System;

namespace polymer.tests.testmodule.Commands
{
	[Route("/organisations/{OrganisationId}", "DELETE", Summary = "deletes an existing organisation")]
	[Route("/organisations/bykey/{Key}", "DELETE", Summary = "deletes an existing organisation using its unique key")]
	public class DeleteOrganisation : ICommand<DeleteOrganisationResult>, IReturn<DeleteOrganisationResult>
	{
		public string OrganisationId { get; set; }
		public Guid Key { get; set; }
	}

	public class DeleteOrganisationResult : ICommandResult
	{

	}
}