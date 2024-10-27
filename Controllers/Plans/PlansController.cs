using POS.Datos;
using System.Web.Mvc;

namespace POS.Controllers.Plans
{
    public class PlansController : Controller
    {
        PlanAdmin admin = new PlanAdmin();

        // GET: Plans
        public ActionResult Index()
        {
            return View(admin.ConsultaPlan());
        }

    }
}