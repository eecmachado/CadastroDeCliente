using Autofac;
using CadastroDeCliente.Application.Interfaces.Repositories;
using CadastroDeCliente.Infra.Data.NHibernateDataAccess.Repositories;

namespace CadastroDeCliente.Infra.CrossCutting.IoC
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
               .RegisterAssemblyTypes(typeof(IRepository<>).Assembly)
               .AsImplementedInterfaces().InstancePerLifetimeScope();            
        }
    }
}