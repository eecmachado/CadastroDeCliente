using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeCliente.Api.Response
{
    public sealed class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}
