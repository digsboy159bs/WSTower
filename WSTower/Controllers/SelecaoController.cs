using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTower.Repositories;

namespace WSTower.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SelecaoController : ControllerBase
    {
        SelecaoRepository selecaoRepository = new SelecaoRepository();

        [HttpGet]
        public IActionResult ListarSelecoes()
        {
            return Ok(selecaoRepository.Listar());
        }
    }
}
