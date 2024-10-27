using POS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace POS.Datos
{
    public class FacultyAdmin
    {
        public void Guardar(Faculty Employee)
        {
            using (Cafeteria_POSEntities context = new Cafeteria_POSEntities())
            {
                context.Faculties.Add(Employee);
                context.SaveChanges();
            }
        }

        public IEnumerable<Faculty> Consultar()
        {
            using (Cafeteria_POSEntities context = new Cafeteria_POSEntities())
            {
                return context.Faculties.Include(p => p.Plan).AsNoTracking().ToList();
                //AsNoTracking para no hacer copia en  memoria porque no se hace ningun CRUD 
            }
        }

    }
}