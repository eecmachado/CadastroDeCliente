using CadastroDeCliente.Domain.Entities;
using System.Threading.Tasks;

namespace CadastroDeCliente.Application.Interfaces.Repositories
{
    public interface IClienteRepository : IRepository<ClienteModel>
    {
        Task<ClienteModel> ObterPorCpfAsync(string placa);
    }
}
