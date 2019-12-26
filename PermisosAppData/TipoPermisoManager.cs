
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermisosAppData
{
    public class TipoPermisoManager
    {

       
        public List<TipoPermiso> Get()
        {

            List<TipoPermiso> ret = new List<TipoPermiso>();

    //        CreateMockData();

            ret = GetTipoPermisos();

            return ret;
        }

        public bool Delete(TipoPermiso entity)
        {
            //TODO: ELIMINA UN EMEPLEADO
            using (var context = new PermisosAppDbContext())
            {

                 context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

                

            }


            return true;

        }

        private List<TipoPermiso> GetTipoPermisos()
        {
            List<TipoPermiso> ret = new List<TipoPermiso>();

            using (var context = new PermisosAppDbContext())
            {

                ret = context.TipoPermisos.ToList();

                return ret;

            }

        }
            private List<TipoPermiso> CreateMockData()
        {

            List<TipoPermiso> ret = new List<TipoPermiso>();

            ret.Add(new TipoPermiso()
            {
                Id = 1,
                PermisoDescripcion = "Vacaciones"
            });

            ret.Add(new TipoPermiso()
            {
                Id = 2,
                PermisoDescripcion = "Consulta Medico"
            });

            ret.Add(new TipoPermiso()
            {
                Id = 3,
                PermisoDescripcion = "Duelo"

            });

            ret.Add(new TipoPermiso()
            {
                Id = 4,
                PermisoDescripcion = "Paternidad"

            });

            ret.Add(new TipoPermiso()
            {
                Id = 5,
                PermisoDescripcion = "Maternidad"

            });

            using (var context = new PermisosAppDbContext())
            {

                foreach (var Entity in ret)
                {

                    var exist = context.TipoPermisos.Where(n => n.PermisoDescripcion == Entity.PermisoDescripcion).FirstOrDefault();
                    if (exist == null){ 
                        context.TipoPermisos.Add(Entity);
                        context.SaveChanges();
                    }
                }

               


            }
            

            return ret;


            
        }
    }
}