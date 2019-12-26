using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace PermisosCommon
{
    public class ViewModelBase : IPermisosAppData
    {

        public ViewModelBase() 
        {
            Init();
        }

        public string EventCommand { get; set; }
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }        
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        public string EventArgument { get; set; }


        protected virtual void ListMode()
        {
            IsValid = true;
            IsDetailAreaVisible = false;
            IsListAreaVisible = true;
            EventCommand = "list";
            Mode = "List";
        }

        protected virtual void AddMode()
        {
            IsListAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Add";

        }

        protected virtual void Init()
        {
            IsListAreaVisible = true;
            IsDetailAreaVisible = false;
            EventArgument = string.Empty;

        }

        protected virtual void Get()
        {

        }

        protected virtual void Add()
        {
            AddMode();

        }

        protected virtual void Delete()
        {

            ListMode();
        }


        protected virtual void Save()
        {
                        
                if (Mode == "Add")
                {
                    AddMode();

                }       


        }

        public virtual void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {

                case "delete":
                    Delete();
                    break;

                case "list":
                    Get();
                    break;

                case "add":
                    Add();
                    break;

                case "cancel":
                    ListMode();
                    Get();
                    break;

                case "save":

                    Save();
                    if (IsValid)
                    {
                        Get();

                    }
                    break;

                default:
                    break;
            }

        }

        void IPermisosAppData.Get()
        {
            throw new NotImplementedException();
        }

        void IPermisosAppData.Add()
        {
            throw new NotImplementedException();
        }

        void IPermisosAppData.Delete()
        {
            throw new NotImplementedException();
        }
    }
}
