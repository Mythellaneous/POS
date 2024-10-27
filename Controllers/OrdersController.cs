using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index(Order order )
        {
            return View(order);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }
        
        [HttpPost]
        [ActionName("Guardar")]
        public ActionResult NuevoPost(Order orden)
        {
            if (ModelState.IsValid)
            {
                Cafeteria_POSEntities context = new Cafeteria_POSEntities();
                context.Orders.Add(orden);
                context.SaveChanges();
                ViewBag.mensaje = "Informacion Guardada";
                return RedirectToAction("Index");
            }
            return View(orden);
        }

        public ActionResult Guardar() // HTTP GET
        {
            ViewBag.mensaje = "";
            ViewBag.Meal_Plan = "";
            return View();
        }
    }
}