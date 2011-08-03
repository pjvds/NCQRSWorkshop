using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ncqrs.Config.StructureMap;
using Commands;
using Ncqrs.Commanding.ServiceModel;
using CommandExecutors;
using Ncqrs;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Storage.SQL;

namespace Web
{
	public static class Bootstrapper
	{
		public static void BootUp()
		{
			var cfg = new StructureMapConfiguration(i =>
			{
				i.For<ICommandService>().Use(InitializeCommandService());
				i.For<IEventStore>().Use(InitializeEventStore());
			});

			NcqrsEnvironment.Configure(cfg);
		}

		private static ICommandService InitializeCommandService()
		{
			var service = new CommandService();
			service.RegisterExecutor(new CreateNewVoyageCommandExecutor());

			return service;
		}

		private static IEventStore InitializeEventStore()
		{
			var store = new MsSqlServerEventStore(@"Data Source=.\sqlexpress;Initial Catalog=NCQRSWorkshopEventStore;Integrated Security=True");
			return store;
		}
	}
}