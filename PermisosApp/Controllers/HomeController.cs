using PermisosAppData;

using PermisosCommon;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PermisosApp.Controllers
{
    public class HomeController : Controller        
    {
        IPermisosAppData db;
        public HomeController(IPermisosAppData db)
        {

            this.db = db;


        }


        public ActionResult Index()
        {
            Database.SetInitializer(new NullDatabaseInitializer<PermisosAppDbContext>());
            EmpleadoViewModel vm = new EmpleadoViewModel();

            vm.HandleRequest();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(EmpleadoViewModel vm)
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