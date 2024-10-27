using POS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace POS.Datos
{
    public class KU_StudentsAdmin
    {
        public void Guardar(KU_Students KU_Students)
        {
            using(Cafeteria_POSEntities context = new Cafeteria_POSEntities())
            {
                context.KU_Students.Add(KU_Students); 
                context.SaveChanges();
            }
        }

        public IEnumerable<KU_Students> Consultar()
        {
            using (Cafeteria_POSEntities context = new Cafeteria_POSEntities())
            {
                return context.KU_Students.Include(p => p.Plan).AsNoTracking().ToList();
                //AsNoTracking para no hacer copia en  memoria porque no se hace ningun CRUD 
            }
        }
    }
}