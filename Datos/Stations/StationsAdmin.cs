using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Datos.Stations
{
    public class StationsAdmin
    {
        public IEnumerable<Station> ConsultarEstacion()
        {
            using (Cafeteria_POSEntities context = new Cafeteria_POSEntities())
            {
                return context.Stations.AsNoTracking().ToList();
                //AsNoTracking para no hacer copia en  memoria porque no se hace ningun CRUD 
            }
        }
    }
}