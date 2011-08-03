using Commands;
using Domain;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;

namespace CommandExecutors
{
	public class CreateNewVoyageCommandExecutor : CommandExecutorBase<CreateNewVoyageCommand>
	{
		protected override void ExecuteInContext(IUnitOfWorkContext context, CreateNewVoyageCommand command)
		{
			var voyage = new Voyage(command.Id, command.Capacity, command.DepartureDate, command.ArrivalDate);

			context.Accept();
		}
	}
}
