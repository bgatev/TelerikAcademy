using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Data.Entity;

using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Ninject.Web.WebApi;
using Ninject.Web;
using Ninject;

using App.Data;
using App.WebAPI.Infrastructure;


[assembly: OwinStartup(typeof(App.WebAPI.Startup))]

namespace App.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IAppData>().To<AppData>().WithConstructorArgument("context", c => new AppDbContext());

            kernel.Bind<IUserIdProvider>().To<AspNetUserIdProvider>();
        }
    }
}
