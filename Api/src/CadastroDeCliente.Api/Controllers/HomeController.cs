using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeCliente.Api.Controllers
{
    /// <summary/>
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        /// <summary/>
        public ActionResult Index() => new RedirectResult("~/swagger");
    }
}