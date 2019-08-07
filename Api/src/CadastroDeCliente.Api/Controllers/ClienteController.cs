using Microsoft.AspNetCore.Mvc;
using CadastroDeCliente.Api.Response;
using CadastroDeCliente.Application.Interfaces.UseCases;
using CadastroDeCliente.Application.UseCases.Cliente.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeCliente.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController
    {
        private readonly IClienteUseCase clienteUseCase;
        private readonly Presenter presenter;

        public ClienteController(IClienteUseCase clienteUseCase, Presenter presenter)
        {
            this.clienteUseCase = clienteUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody]InserirClienteRequest carro)
        {
            await clienteUseCase.Inserir(carro, presenter);
            return presenter.ContentResult;
        }

        [HttpPut]
        public async Task<IActionResult> Alterar([FromBody]AlterarClienteRequest carroRequest)
        {

            await clienteUseCase.Alterar(carroRequest, presenter);
            return presenter.ContentResult;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(ExcluirClienteRequest carroRequest)
        {
            await clienteUseCase.Excluir(carroRequest, presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            await clienteUseCase.ObterPorId(id, presenter);
            return presenter.ContentResult;
        }

        [HttpGet]
        public async Task<IActionResult> ObterLista()
        {
            await clienteUseCase.ObterLista(presenter);
            return presenter.ContentResult;
        }
    }
}
