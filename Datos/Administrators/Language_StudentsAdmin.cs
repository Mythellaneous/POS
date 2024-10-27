using POS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace POS.Datos
{
    public class Language_StudentsAdmin
    {
        public void Guardar(Language_Students Lang_Student)
        {
            using (Cafeteria_POSEntities context = new Cafeteria_POSEntities())
            {
                context.Language_Students.Add(Lang_Student);
                context.SaveChanges();
            }
        }

        public IEnumerable<Language_Students> Consultar()
        {
            using (Cafeteria_POSEntities context = new Cafeteria_POSEntities())
            {
                return context.Language_Students.Include(p => p.Plan).AsNoTracking().ToList();
                //AsNoTracking para no hacer copia en  memoria porque no se hace ningun CRUD 
            }
        }
    }
}