using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using NHibernate.Linq;
using CadastroDeCliente.Application.Interfaces.Repositories;
using CadastroDeCliente.Domain.Entities.Base;
using CadastroDeCliente.Infra.Data.NHibernateDataAccess.DataModels;
using System;
using System.Linq.Expressions;

namespace CadastroDeCliente.Infra.Data.NHibernateDataAccess.Repositories
{
    public class Repository<TDomainModel, TDataModel> : IRepository<TDomainModel>
        where TDomainModel : DomainModel
        where TDataModel : DataModel
    {
        protected readonly ISessionFactory sessionFactory;
        protected readonly IMapper mapper;

        public Repository(ISessionFactory sessionFactory, IMapper mapper)
        {
            this.sessionFactory = sessionFactory;
            this.mapper = mapper;
        }

        public Expression<Func<TDataModel, bool>> Expression { get; protected set; }

        public async Task<TDomainModel> InserirAsync(TDomainModel domainModel)
        {
            var dataModel = mapper.Map<TDataModel>(domainModel);

            using (var session = sessionFactory.OpenSession())
            {
                await session.SaveAsync(dataModel);
                await session.FlushAsync();
                domainModel.Id = dataModel.Id;
                return domainModel;
            }
        }

        public async Task<TDomainModel> AlterarAsync(TDomainModel domainModel)
        {
            var dataModel = mapper.Map<TDataModel>(domainModel);

            using (var session = sessionFactory.OpenSession())
            {
                await session.UpdateAsync(dataModel);
                await session.FlushAsync();
                return domainModel;
            }
        }

        public async Task ExcluirAsync(int id)
        {
            using (var session = sessionFactory.OpenSession())
            {
                await session.DeleteAsync(await session.LoadAsync<TDataModel>(id));
                await session.FlushAsync();
            }
        }

        public async Task<TDomainModel> ObterPorIdAsync(int id)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var dataModel = await session.GetAsync<TDataModel>(id);
                return mapper.Map<TDomainModel>(dataModel);
            }
        }

        public async Task<IEnumerable<TDomainModel>> ObterListaAsync()
        {
            using (var session = sessionFactory.OpenSession())
            {
                var lista = await session.Query<TDataModel>().ToListAsync();
                return mapper.Map<IEnumerable<TDomainModel>>(lista);
            }
        }

        public async Task<bool> ExisteAsync(int id)
        {
            using (var session = sessionFactory.OpenSession())
            {
                return await session.Query<TDataModel>().AnyAsync(a => a.Id == id);
            }
        }
    }
}