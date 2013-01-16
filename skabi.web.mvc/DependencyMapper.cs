using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Ninject.Modules;
using Ninject.Web.Common;
using skabi.data;
using skabi.data.Repository.Interfaces;
using skabi.data.Repository;

namespace skabi.web.mvc
{
    public class DependencyMapper : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>();

            this.Bind<DbContext>().ToSelf().InRequestScope();
            //this.Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument();


            this.Bind<ICarbrandRepository>()
                .To<CarbrandRepository>();
            //.WithConstructorArgument("context", ContextFactory.GetDatabaseContext(false, ""));
            //.WithConstructorArgument("work", ContextFactory.GetUnitOfWorkContext(false, null));


        }
    }
}