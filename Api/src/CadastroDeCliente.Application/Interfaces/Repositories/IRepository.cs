using CadastroDeCliente.Domain.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroDeCliente.Application.Interfaces.Repositories
{
    public interface IRepository<TDomainModel> where TDomainModel : IDomainModel
    {
        Task<TDomainModel> InserirAsync(TDomainModel obj);
        Task<TDomainModel> AlterarAsync(TDomainModel obj);
        Task ExcluirAsync(int id);
        Task<TDomainModel> ObterPorIdAsync(int id);
        Task<IEnumerable<TDomainModel>> ObterListaAsync();
        Task<bool> ExisteAsync(int id);
    }
}