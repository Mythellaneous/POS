using POS.Datos;
using POS.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class Languague_StudentsController : Controller
    {
        Language_StudentsAdmin admin = new Language_StudentsAdmin();

        // GET: Languague_Students
        public ActionResult Index()
        {
            return View(admin.Consultar());
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            ViewBag.Meal_Plan = GetPlanesSelect();
            admin.Consultar();
            return View();
        }

        [HttpPost]
        [ActionName("Guardar")]
        public ActionResult NuevoPost(Language_Students Lang_Student)
        {
            if (ModelState.IsValid)
            {
                admin.Consultar();
                using (Cafeteria_POSEntities context = new Cafeteria_POSEntities())
                {
                    context.Language_Students.Add(Lang_Student);
                    context.SaveChanges();
                    ViewBag.mensaje = "Informacion Guardada";
                    return RedirectToAction("Index");
                }
            }
            return View(Lang_Student);
        }

        [HttpGet]
        public ActionResult Guardar() // HTTP GET
        {
            ViewBag.mensaje = "";
            ViewBag.Meal_Plan = GetPlanesSelect();
            return View();
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Cafeteria_POSEntities context = new Cafeteria_POSEntities();
            Language_Students Lang_Student = context.Language_Students.Single(x => x.Student_ID == id);
            ViewBag.Meal_Plan = GetPlanesSelect();
            return View(Lang_Student);
        }


        [HttpPost]
        [ActionName("Editar")]
        public ActionResult Editar(Language_Students Lang_Student)
        {
            if (ModelState.IsValid)
            {
                Cafeteria_POSEntities context = new Cafeteria_POSEntities();
                context.Entry(Lang_Student).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Lang_Student);

        }

        public IEnumerable<SelectListItem> GetPlanesSelect()
        {
            using (Cafeteria_POSEntities Context = new Cafeteria_POSEntities())
            {
                return Context.Plans.Select(plan => new SelectListItem { Value = plan.Plan_Name, Text = plan.Plan_Name }).ToList();
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Cafeteria_POSEntities context = new Cafeteria_POSEntities();
            Language_Students Lang_Student = context.Language_Students.Single(x => x.Student_ID == id);
            return View(Lang_Student);
        }

        [HttpPost]
        [ActionName("Eliminar")]
        public ActionResult EliminarConfirm(int id)
        {
            Cafeteria_POSEntities context = new Cafeteria_POSEntities();
            Language_Students Lang_Student = context.Language_Students.Single(x => x.Student_ID == id);
            context.Language_Students.Remove(Lang_Student);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}