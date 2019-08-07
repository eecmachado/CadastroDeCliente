using CadastroDeCliente.Application.UseCases.Cliente.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroDeCliente.Application.Interfaces.UseCases
{
    public interface IClienteUseCase
    {
        Task Inserir(InserirClienteRequest CarroRequest, IOutputPort<ClienteResponse> outputPort);
        Task Alterar(AlterarClienteRequest CarroRequest, IOutputPort<ClienteResponse> outputPort);
        Task Excluir(ExcluirClienteRequest CarroRequest, IOutputPort<ClienteResponse> outputPort);
        Task ObterPorId(int id, IOutputPort<ClienteResponse> outputPort);
        Task ObterLista(IOutputPort<IEnumerable<ClienteResponse>> outputPort);
    }
}
