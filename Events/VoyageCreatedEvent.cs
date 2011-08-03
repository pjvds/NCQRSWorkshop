using System;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Sourcing;

namespace Events
{
	public class VoyageCreatedEvent : SourcedEvent
	{
		public Guid Id { get; private set; }
		public int Capacity { get; private set; }
		public int CapacityUsed { get; private set; }
		public int CapacityLeft { get; private set; }
		public DateTime DepartureDate { get; private set; }
		public DateTime ArrivalDate { get; private set; }

		public VoyageCreatedEvent(Guid id, int capacity, int capacityUsed, int capacityLeft, DateTime departureDate, DateTime arrivalDate)
		{
			Id = id;
			Capacity = capacity;
			CapacityUsed = capacityUsed;
			CapacityLeft = capacityLeft;
			DepartureDate = departureDate;
			ArrivalDate = arrivalDate;
		}
	}
}
