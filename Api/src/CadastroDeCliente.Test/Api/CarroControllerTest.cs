using CrudClean.Api.Controllers;
using CrudClean.Api.Response;
using CrudClean.Application.Interfaces;
using CrudClean.Application.Interfaces.UseCases;
using CrudClean.Application.UseCases.Carro.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CrudClean.Test.Api
{
    public sealed class CarroControllerTest
    {
        private readonly Mock<ICarroUseCase> mockCarroUseCase;
        private readonly Mock<Presenter> mockPresenter;
        private readonly Mock<IOutputPort<CarroResponse>> mockOutputPort;
        private readonly CarroController carroController;
        private readonly CarroBuilder carroBuilder;

        public CarroControllerTest()
        {
            mockCarroUseCase = new Mock<ICarroUseCase>();
            mockPresenter = new Mock<Presenter>();
            mockOutputPort = new Mock<IOutputPort<CarroResponse>>();
            carroBuilder = new CarroBuilder();

            carroController = new CarroController(
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
