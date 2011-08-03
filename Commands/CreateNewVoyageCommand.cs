using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;

namespace Commands
{
	public class CreateNewVoyageCommand : CommandBase
	{
		public Guid Id { get; set; }
		public int Capacity { get; set; }
		public DateTime DepartureDate { get; set; }
		public DateTime ArrivalDate { get; set; }
	}
}
