using System;
using Events;
using Ncqrs.Domain;

namespace Domain
{
	public class Voyage : AggregateRootMappedByConvention
	{
		private int _capacity;
		private int _capacityUsed;
		private int _capacityLeft;
		private DateTime _departureDate;
		private DateTime _arrivalDate;

		public Voyage(Guid id, int capacity, DateTime departuredate, DateTime arrivalDate) : base(id)
		{
			var e = new VoyageCreatedEvent(id, capacity, 0, capacity, departuredate, arrivalDate);

			ApplyEvent(e);
		}

		protected void OnVoyageCreated(VoyageCreatedEvent e)
		{
			_capacity = e.Capacity;
			_capacityUsed = e.CapacityUsed;
			_capacityLeft = e.CapacityLeft;
			_departureDate = e.DepartureDate;
			_arrivalDate = e.ArrivalDate;
		}
	}
}
