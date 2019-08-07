using CadastroDeCliente.Api.Controllers;
using CadastroDeCliente.Api.Response;
using CadastroDeCliente.Application.Interfaces;
using CadastroDeCliente.Application.Interfaces.UseCases;
using CadastroDeCliente.Application.UseCases.Cliente.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroDeCliente.Test.Api
{
    public sealed class CarroControllerTest
    {
        private readonly Mock<IClienteUseCase> mockCarroUseCase;
        private readonly Mock<Presenter> mockPresenter;
        private readonly Mock<IOutputPort<ClienteResponse>> mockOutputPort;
        private readonly ClienteController carroController;
        private readonly CarroBuilder carroBuilder;

        public CarroControllerTest()
        {
            mockCarroUseCase = new Mock<IClienteUseCase>();
            mockPresenter = new Mock<Presenter>();
            mockOutputPort = new Mock<IOutputPort<ClienteResponse>>();
            carroBuilder = new CarroBuilder();

            carroController = new ClienteController(
                    mockCarroUseCase.Object,
                    mockPresenter.Object);
        }

        [Fact]
        public async Task InserirOk()
        {
            var carroRequest = new InserirCarroRequest();

            mockCarroUseCase
                .Setup(s => s.Inserir(carroRequest, mockPresenter.Object))
                .Returns(carroBuilder.RetornoValido(mockOutputPort.Object));

            var actionResult = await carroController.Inserir(carroRequest);
            var response = actionResult as ObjectResult;

            mockCarroUseCase.Verify(v => v.Inserir(It.IsAny<InserirCarroRequest>(), It.IsAny<Presenter>()), Times.Once);
            Assert.Equal(StatusCodes.Status200OK, response.StatusCode.Value);
        }

        //[Fact]
        //public async Task InserirCatalogoDeMarcaOk()
        //{
        //    var command = new InserirCatalogoDeMarcaCommand();
        //    var actionResult = await catalogoDeMarcaController.Post(command);
        //    var response = actionResult as ObjectResult;

        //    mockMediatorHandler.Verify(v => v.Send<InserirCatalogoDeMarcaCommand, CommandResponse>(It.IsAny<InserirCatalogoDeMarcaCommand>()), Times.Once);
        //    Assert.Equal(StatusCodes.Status200OK, response.StatusCode.Value);
        //}

        //[Fact]
        //public async Task ObterSugestaoMarcaOk()
        //{
        //    mockCatalogoDeMarcaBO
        //        .Setup(s => s.ObterSugestaoCatalogoDeMarca(1, config.Object.QuantProdutosMarcasSugestao))
        //        .Returns(Task.FromResult(new RetornoSugestaoCatalogoDeMarcaBO(new List<RetornoSugestaoCatalogoDeMarcaVO>())));

        //    var actionResult = await catalogoDeMarcaController.ObterSugestao(1);
        //    var response = actionResult as ObjectResult;

        //    mockCatalogoDeMarcaBO.Verify(v => v.ObterSugestaoCatalogoDeMarca(1, config.Object.QuantProdutosMarcasSugestao), Times.Once);
        //    Assert.Equal(StatusCodes.Status200OK, response.StatusCode.Value);
        //}

    }
}
