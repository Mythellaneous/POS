using POS.Datos.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Controllers.Stations
{
    public class StationsController : Controller
    {
        StationsAdmin admin = new StationsAdmin();

        // GET: Stations
        public ActionResult Index()
        {
            return View(admin.ConsultarEstacion());
        }
    }
}