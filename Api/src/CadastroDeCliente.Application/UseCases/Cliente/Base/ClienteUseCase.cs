using AutoMapper;
using CadastroDeCliente.Application.Interfaces;
using CadastroDeCliente.Application.Interfaces.Repositories;
using CadastroDeCliente.Application.Interfaces.UseCases;
using CadastroDeCliente.Application.Resources;
using CadastroDeCliente.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeCliente.Application.UseCases.Cliente.Base
{
    public class ClienteUseCase : IClienteUseCase
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IValidator<InserirClienteRequest> inserirClienteValidator;
        private readonly IValidator<AlterarClienteRequest> alterarClienteValidator;
        private readonly IValidator<ExcluirClienteRequest> excluirClienteValidator;
        private readonly IMapper mapper;

        public ClienteUseCase(IClienteRepository clienteRepository,
            IValidator<InserirClienteRequest> inserirClienteValidator,
            IValidator<AlterarClienteRequest> alterarClienteValidator,
            IValidator<ExcluirClienteRequest> excluirClienteValidator,
            IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.inserirClienteValidator = inserirClienteValidator;
            this.alterarClienteValidator = alterarClienteValidator;
            this.excluirClienteValidator = excluirClienteValidator;
            this.mapper = mapper;
        }


        public async Task Inserir(InserirClienteRequest clienteRequest, IOutputPort<ClienteResponse> outputPort)
        {
            var validations = inserirClienteValidator.Validate(clienteRequest);

            if (!validations.IsValid)
            {
                outputPort.Handler(new ClienteResponse(validations.Errors.Select(x => x.ErrorMessage)));
                return;
            }

            var clienteModel = await clienteRepository.ObterPorCpfAsync(clienteRequest.Cpf);

            if (clienteModel != null)
            {
                outputPort.Handler(new ClienteResponse(Mensagens.IdNaoEncontrado));
                return;
            }

            clienteModel = mapper.Map<ClienteModel>(clienteRequest);
            await clienteRepository.InserirAsync(clienteModel);

            outputPort.Handler(mapper.Map<ClienteResponse>(clienteModel));
        }

        public async Task Alterar(AlterarClienteRequest clienteRequest, IOutputPort<ClienteResponse> outputPort)
        {
            var validations = alterarClienteValidator.Validate(clienteRequest);

            if (!validations.IsValid)
            {
                outputPort.Handler(new ClienteResponse(validations.Errors.Select(x => x.ErrorMessage)));
                return;
            }

            var clienteModel = await clienteRepository.ObterPorIdAsync(clienteRequest.Id);

            if (clienteModel == null)
            {
                outputPort.Handler(new ClienteResponse(Mensagens.IdNaoEncontrado));
                return;
            }

            clienteModel = mapper.Map(clienteRequest, clienteModel);

            await clienteRepository.AlterarAsync(clienteModel);

            outputPort.Handler(mapper.Map<ClienteResponse>(clienteModel));
        }

        public async Task Excluir(ExcluirClienteRequest clienteRequest, IOutputPort<ClienteResponse> outputPort)
        {
            var validations = excluirClienteValidator.Validate(clienteRequest);

            if (!validations.IsValid)
            {
                outputPort.Handler(new ClienteResponse(validations.Errors.Select(x => x.ErrorMessage)));
                return;
            }

            var clienteModel = await clienteRepository.ObterPorIdAsync(clienteRequest.Id);

            if (clienteModel == null)
            {
                outputPort.Handler(new ClienteResponse(Mensagens.IdNaoEncontrado));
                return;
            }

            await clienteRepository.ExcluirAsync(clienteModel.Id);
        }

        public async Task ObterPorId(int id, IOutputPort<ClienteResponse> outputPort)
        {
            var clienteModel = await clienteRepository.ObterPorIdAsync(id);

            if (clienteModel != null)
                outputPort.Handler(mapper.Map<ClienteResponse>(clienteModel));
        }

        public async Task ObterLista(IOutputPort<IEnumerable<ClienteResponse>> outputPort)
        {
            outputPort.Handler(mapper.Map<IEnumerable<ClienteResponse>>(await clienteRepository.ObterListaAsync()));
        }

        private async Task<bool> Existe(int id, IOutputPort<ClienteResponse> outputPort)
        {
            var existe = await clienteRepository.ExisteAsync(id);

            if (!existe)
                outputPort.Handler(new ClienteResponse(Mensagens.IdNaoEncontrado));

            return existe;
        }
    }
}
