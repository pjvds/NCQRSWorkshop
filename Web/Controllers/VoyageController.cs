using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.Mvc;
using Commands;
using ReadModel;

namespace Web.Controllers
{
    public class VoyageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult List()
		{
			var context = new DataClassesDataContext();
			var voyages = context.Voyages.ToList();

			return View(voyages);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(CreateNewVoyageCommand command)
		{
			if (ModelState.IsValid)
			{
				command.Id = Guid.NewGuid();
				MvcApplication.CommandService.Execute(command);
			}

			return View();
		}

    }
}
