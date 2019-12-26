using PermisosCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PermisosAppData
{
    public class EmpleadoViewModel : ViewModelBase
    {
        public EmpleadoViewModel() : base()
        {
           
           
        }

        protected override void Init()
        {
             Empleados = new List<Empleado>();
            EventCommand = "list";
            EmpleadoEntity = new Empleado();
         

            base.Init();
        }

        
        public List<Empleado> Empleados { get; set; }

        public Empleado EmpleadoEntity { get; set; }

        public Empleado Entity { get; set; }

        public IEnumerable Permisos { get; set; }



        protected override void AddMode()
        {
            IsListAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Add";

        }



        protected override void Add()
        {
          
            EmpeladoManager mgr = new EmpeladoManager();            

            Permisos = mgr.GetTipoPermisosList();

            base.Add();
        }


      


        protected override void Save()
        {
            EmpeladoManager mgr = new EmpeladoManager();           

            Permisos = mgr.GetTipoPermisosList();

            if (IsValid)
            {
                if(Mode=="Add")
                {
                    //Guarda datos en la DB
                    mgr.Insert(Entity);

                }

            }
            else
            {
                base.Save();

            }
            

        }

        protected override void Get()
        {

            EmpeladoManager mgr = new EmpeladoManager();

            Empleados = mgr.Get();

            Permisos = mgr.GetTipoPermisosList();

            base.Get();

        }

        public override void HandleRequest()
        {

            base.HandleRequest();

        }


    }
}
