using POS.Datos;
using POS.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class KU_StudentsController : Controller
    {
        KU_StudentsAdmin admin = new KU_StudentsAdmin();

        // GET: KU_Students
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
        public ActionResult NuevoPost(KU_Students ku_Student)
        {
            if (ModelState.IsValid)
            {
                admin.Consultar();
                using (Cafeteria_POSEntities context = new Cafeteria_POSEntities()) 
                {
                    context.KU_Students.Add(ku_Student);
                    context.SaveChanges();
                    ViewBag.mensaje = "Informacion Guardada";
                    return RedirectToAction("Index");
                }
                
            }
            return View(ku_Student);
        }

        public ActionResult Guardar() // HTTP GET
        {
            ViewBag.mansaje = "";
            ViewBag.Meal_Plan = GetPlanesSelect();
            return View();
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Cafeteria_POSEntities context = new Cafeteria_POSEntities();
            KU_Students ku_Student = context.KU_Students.Single(x => x.Student_ID == id);
            ViewBag.Meal_Plan = GetPlanesSelect();
            return View(ku_Student);
        }

        [HttpPost]
        [ActionName("Editar")]
        public ActionResult Editar(KU_Students ku_Student)
        {
            if (ModelState.IsValid)
            {
                Cafeteria_POSEntities context = new Cafeteria_POSEntities();
                context.Entry(ku_Student).State = EntityState.Modified; 
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ku_Student);
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
            KU_Students ku_Student = context.KU_Students.Single(x => x.Student_ID == id);
            return View(ku_Student);
        }

        [HttpPost]
        [ActionName("Eliminar")]
        public ActionResult EliminarConfirm(int id)
        {
            Cafeteria_POSEntities context = new Cafeteria_POSEntities();
            KU_Students ku_Student = context.KU_Students.Single(x => x.Student_ID == id);
            context.KU_Students.Remove(ku_Student);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}