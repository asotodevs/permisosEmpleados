using PermisosAppData;
using System.Data.Entity;
using System.Web.Mvc;

namespace PermisosApp.Controllers
{
    public class TipoPermisoController : Controller
    {

        public ActionResult TipoPermiso()
        {
            Database.SetInitializer(new NullDatabaseInitializer<PermisosAppDbContext>());
            ViewBag.Message = "Tipo de Permiso Existente.";

            TipoPermisoViewModel vm = new TipoPermisoViewModel();

            vm.HandleRequest();

            return View(vm);
        }



        [HttpPost]
        public ActionResult TipoPermiso(TipoPermisoViewModel vm)
        {
            vm.IsValid = ModelState.IsValid;
            vm.HandleRequest();

            if (vm.IsValid)
            {
                ModelState.Clear();
            }
            return View(vm);
        }



    }
}