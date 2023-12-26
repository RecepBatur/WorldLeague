using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DepedencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TeamManager>().As<ITeamService>();
            builder.RegisterType<EfTeamDal>().As<ITeamDal>();

            builder.RegisterType<GroupManager>().As<IGroupService>();
            builder.RegisterType<EfGroupDal>().As<IGroupDal>();

            builder.RegisterType<DrawResultManager>().As<IDrawResultService>();
            builder.RegisterType<EfDrawResultDal>().As<IDrawResultDal>();

            builder.RegisterType<CountryManager>().As<ICountryService>();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>();
        }
    }
}
