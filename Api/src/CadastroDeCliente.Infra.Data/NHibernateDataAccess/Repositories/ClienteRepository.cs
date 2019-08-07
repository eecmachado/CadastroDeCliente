using AutoMapper;
using NHibernate;
using CadastroDeCliente.Application.Interfaces.Repositories;
using CadastroDeCliente.Domain.Entities;
using CadastroDeCliente.Infra.Data.NHibernateDataAccess.DataModels;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace CadastroDeCliente.Infra.Data.NHibernateDataAccess.Repositories
{
    public class ClienteRepository : Repository<ClienteModel, ClienteData>, IClienteRepository
    {
        public ClienteRepository(ISessionFactory sessionFactory, IMapper mapper)
            : base(sessionFactory, mapper)
        {

        }

        public async Task<ClienteModel> ObterPorCpfAsync(string cpf)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var retorno = await session.Query<ClienteData>()
                    .SingleOrDefaultAsync(s => s.Cpf == cpf);

                return mapper.Map(retorno, new ClienteModel());
            }
        }
    }
}
