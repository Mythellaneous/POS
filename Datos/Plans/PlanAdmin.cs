using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Datos
{
    public class PlanAdmin
    {
        public IEnumerable<Plan> ConsultaPlan()
        {
            using (Cafeteria_POSEntities context = new Cafeteria_POSEntities())
            {
                return context.Plans.AsNoTracking().ToList();
                //AsNoTracking para no hacer copia en  memoria porque no se hace ningun CRUD 
            }
        }
    }
}