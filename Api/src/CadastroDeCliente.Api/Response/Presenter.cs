using CadastroDeCliente.Api.Serialization;
using CadastroDeCliente.Application;
using CadastroDeCliente.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CadastroDeCliente.Api.Response
{
    public class Presenter : IOutputPort<UseCaseResponseMessage>, IOutputPort<IEnumerable<UseCaseResponseMessage>>
    {
        public JsonContentResult ContentResult { get; }

        public Presenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handler(UseCaseResponseMessage response)
        {
            var isValid = response.IsValid();
            ContentResult.StatusCode = (int)(isValid ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = isValid ? JsonSerializer.SerializeObject(response) : JsonSerializer.SerializeObject(response.Errors);
        }

        public void Handler(IEnumerable<UseCaseResponseMessage> response)
        {
            ContentResult.StatusCode = (int)HttpStatusCode.OK;
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }     
    }
}
