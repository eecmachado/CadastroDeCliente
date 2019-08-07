using Autofac;
using CadastroDeCliente.Infra.Data.NHibernateDataAccess.Repositories;
using CadastroDeCliente.Infra.Data.NHibernateDataAccess;

namespace CadastroDeCliente.Infra.CrossCutting.IoC
{
    public class InfraModule : Module
    {
        private readonly string connectionString;

        public InfraModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
               .RegisterAssemblyTypes(typeof(Repository<,>).Assembly)
               .AsImplementedInterfaces().InstancePerLifetimeScope();

            var sessionFactory = NHibernateHelper.ConfigureSessionFactory(a =>
            {
                a.ConnectionString = connectionString;
                a.ShowSql = true;
                a.DatabaseType = DatabaseType.mssql_12;
            });

            builder.Register(f => sessionFactory).SingleInstance();
        }
    }
}