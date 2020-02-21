using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ShopyEcomerce;
using ShopyEcomerce.ef;
using ShopyLibrary;
using ShopyLibrary.Interface;


namespace Shopy.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterContainer()
        {
            var build = new ContainerBuilder();
            build.RegisterControllers(typeof(MvcApplication).Assembly);
            build.RegisterType<EcommerceDb>().InstancePerRequest();
            build.RegisterType<Productsdb>().As<IProducts>().InstancePerRequest();
            build.RegisterType<CartsDb>().As<ICarts>().InstancePerRequest();
            build.RegisterType<OrdersDb>().As<IOrders>().InstancePerRequest();
          var container =  build.Build();
          DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}