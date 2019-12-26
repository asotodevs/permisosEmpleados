using PermisosCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace PermisosAppData
{
    public class TipoPermisoViewModel : ViewModelBase
    {
        public TipoPermisoViewModel()
        {
    

        }

     

        protected override void Init()
        {
            Permisos = new List<TipoPermiso>();
            EventCommand = "list";
            TipoPermisoEntity = new TipoPermiso();
            base.Init();
        }


          public List<TipoPermiso> Permisos { get; set; }

        public TipoPermiso TipoPermisoEntity { get; set; }

        public TipoPermiso Entity { get; set; }


        protected override void Delete()
        {

            TipoPermisoManager mgr = new TipoPermisoManager();
            Entity = new TipoPermiso();
            Entity.Id = Convert.ToInt32(EventArgument);

            mgr.Delete(Entity);

            Get();
            base.Delete();

        }

        protected override void AddMode()
        {
            IsListAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Add";

        }




        protected override void Get()
        {

            TipoPermisoManager mgr = new TipoPermisoManager();

            Permisos = mgr.Get();

            base.Get();

        }

        public override void HandleRequest()
        {

            base.HandleRequest();


        }
    }
    }
