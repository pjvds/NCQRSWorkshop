using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace ReadModel.Denormalizers
{
	public class VoyageCreatedDenormalizer : IEventHandler<VoyageCreatedEvent>
	{
		public void Handle(VoyageCreatedEvent e)
		{
			var context = new DataClassesDataContext();

			var voyage = new Voyage();
			voyage.Id = e.Id;
			voyage.Capacity = e.Capacity;
			voyage.CapacityLeft = e.CapacityLeft;
			voyage.CapacityUsed = e.CapacityUsed;
			voyage.DepartureDate = e.DepartureDate;
			voyage.ArrivalDate = e.ArrivalDate;

			context.Voyages.InsertOnSubmit(voyage);
			context.SubmitChanges();
		}
	}
}
