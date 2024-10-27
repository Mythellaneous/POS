using POS.Datos;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class FacultyController : Controller
    {
        FacultyAdmin admin = new FacultyAdmin();

        // GET: Faculty
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
        public ActionResult NuevoPost(Faculty empleado)
        {
            admin.Consultar();
            if (ModelState.IsValid)
                {
                Cafeteria_POSEntities context = new Cafeteria_POSEntities();
                admin.Consultar();
                context.Faculties.Add(empleado);
                context.SaveChanges();
                ViewBag.mensaje = "Informacion Guardada";
                return RedirectToAction("Index");
                }
            return View(empleado);
        }
        
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
            Faculty empleado = context.Faculties.Single(x => x.Employee_ID == id); 
            ViewBag.Meal_Plan = GetPlanesSelect();
            return View(empleado);
        }

        [HttpPost]
        [ActionName("Editar")]
        public ActionResult Editar(Faculty empleado, int id)
        {
            if (ModelState.IsValid)
            {
                Cafeteria_POSEntities context = new Cafeteria_POSEntities();
                empleado = context.Faculties.Single(x => x.Employee_ID == id);
                context.Entry(empleado).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        public IEnumerable<SelectListItem> GetPlanesSelect()
        {
            using (Cafeteria_POSEntities Context = new Cafeteria_POSEntities())
            {
                return Context.Plans.Select(plan => new SelectListItem { Value = plan.Plan_Name, Text = plan.Plan_Name }).ToList();
            }
        }

        [HttpGet]
        public ActionResult Detalles(int id)
        {
            if (ModelState.IsValid)
            {
                Cafeteria_POSEntities context = new Cafeteria_POSEntities();
                Faculty empleado = context.Faculties.Single(x => x.Employee_ID == id);
                ViewBag.Meal_Plan = GetPlanesSelect();
                admin.Consultar();
                return View(empleado);
            }
            return View("Detalles");
        }
        [HttpPost]
        [ActionName("Detalles")]
        public ActionResult DetallesPost(int id)
        {
            if (ModelState.IsValid)
            {
                Cafeteria_POSEntities context = new Cafeteria_POSEntities();
                Faculty empleado = context.Faculties.Single(x => x.Employee_ID == id);
                ViewBag.Meal_Plan = GetPlanesSelect();
                admin.Consultar();
                return View(empleado);
            }
            return View("Detalles");
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Cafeteria_POSEntities context = new Cafeteria_POSEntities();
            Faculty empleado = context.Faculties.Single(x => x.Employee_ID == id);
            return View(empleado);
        }

        [HttpPost]
        [ActionName("Eliminar")]
        public ActionResult EliminarConfirm(int id)
        {
            Cafeteria_POSEntities context = new Cafeteria_POSEntities();
            Faculty empleado = context.Faculties.Single(x => x.Employee_ID == id);
            context.Faculties.Remove(empleado);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Iniciar Sesion")]
        [ValidateAntiForgeryToken]
        public ActionResult LoginPost(Faculty empleado)
        {
            if (ModelState.IsValid)
            {
                using (Cafeteria_POSEntities context = new Cafeteria_POSEntities())
                {
                    var user = context.Faculties.Where(e => e.Email.Equals(empleado.Email)
                        && e.Password.Equals(empleado.Password)).FirstOrDefault();
                    if (user != null)
                    {
                        Session["UserID"] = user.Employee_ID.ToString();
                        Session["User_Email"] = user.Email.ToString();
                        Session["User_FirstName"] = user.First_Name.ToString();
                        Session["User_LastName"] = user.Last_Name.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
            }
            return View(empleado);
        }


        [HttpGet]
        public ActionResult UserDashBoard()
        {
            return View();
        }

        [HttpPost]
        [ActionName("UserDashBoardPost")]
        public ActionResult UserDashBoardPost()
        {
            if (Session["User_Email"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }

    //j.maltez1@keiseruniversity.edu
    //password123
}
