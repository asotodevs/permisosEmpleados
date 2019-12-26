using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PermisosAppData
{
    public class PermisosAppDbContext : DbContext
    {

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<TipoPermiso> TipoPermisos { get; set; }
    }
}
