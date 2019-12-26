using Autofac;
using Autofac.Integration.Mvc;
using PermisosAppData;
using PermisosCommon;
using System.Web.Mvc;

namespace PermisosApp
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ViewModelBase>().As<IPermisosAppData>().InstancePerRequest();

            builder.RegisterType<PermisosAppDbContext>().InstancePerRequest();
            var container = builder.Build();   
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
          //  httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}