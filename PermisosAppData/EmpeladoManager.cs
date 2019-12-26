

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermisosAppData
{
    public class EmpeladoManager 
    {

      
         

        public List<Empleado> Get()
        {

            List<Empleado> ret = new List<Empleado>();

            using (var context = new PermisosAppDbContext())
            {                 

                var empleados = context.Empleados;
                var TipoPermiso = context.TipoPermisos;

                foreach (Empleado e in empleados)
                {
                    var tp = TipoPermiso.Find(e.TipoPermisoID);

                    e.TipoPermiso = tp;

                    ret.Add(e);


                }


            }

               

            return ret;
        }


        public IEnumerable GetTipoPermisosList()
        {
           
            using (var context = new PermisosAppDbContext())
            {

               return   context.TipoPermisos.OrderBy(n => n.Id)
                  .Select(c => new { c.Id, c.PermisoDescripcion }).ToList();

                 



            }
        }


        public bool Insert(Empleado entity)
        {
            bool ret = false;


            //TOOD: CREATE INSERT IN DB         

            using (var context = new PermisosAppDbContext())
            {

                        context.Empleados.Add(entity);
                        context.SaveChanges();
                         ret = true;
            }


                return ret;

        }

        private List<Empleado> CreateMockData()
        {

            List<Empleado> ret = new List<Empleado>();

            ret.Add(new Empleado()
            {
                Id = 1,
                NombreEmpleado = "Juan",
                ApellidoEmpleado ="Alvarez",
                
            });

            ret.Add(new Empleado()
            {
                Id = 2,
                NombreEmpleado = "Pedro",
                ApellidoEmpleado = "Gonzalez"
            });

            ret.Add(new Empleado()
            {
                Id = 3,
                NombreEmpleado = "Marco",
                ApellidoEmpleado = "Solic"

            });

            ret.Add(new Empleado()
            {
                Id = 4,
                NombreEmpleado = "Valeria",
                ApellidoEmpleado = "Tanco"

            });

            ret.Add(new Empleado()
            {
                Id = 5,
                NombreEmpleado = "Marcelo",
                ApellidoEmpleado = "Milanesio"

            });

            return ret;


            
        }
    }
}