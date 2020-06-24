using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTower.Domains;
using WSTower.Repositories;

namespace WSTower.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        JogoRepository jogoRepository = new JogoRepository();

        [HttpGet]
        public IActionResult ListarConfrontos()
        {
            return Ok(jogoRepository.ListarJogos());
        }

        /*[HttpGet]
        public IActionResult PlacarConfronto()
        {
            return Ok(jogoRepository.PlacarFinal());
        }/*/

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Jogo jogo = jogoRepository.BucarPorId(id);
            if (jogo == null)
            {
                return NotFound();
            }
            return Ok(jogo);
        }

        [HttpPost]
        public IActionResult Cadastrar(Jogo jogo)
        {
            try
            {
                jogoRepository.Cadastrar(jogo);
                return Ok("Jogo Cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Algo deu errado");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            jogoRepository.Deletar(id);
            return Ok("jogo deletado com sucesso");
        }

        [HttpPut]
        public IActionResult Atualizar(Jogo jogo)
        {
            try
            {
                Jogo jogoBuscado = jogoRepository.BucarPorId(jogo.Id);
                if (jogoBuscado == null)
                    return NotFound();
                jogoRepository.Atualizar(jogoBuscado);
                return Ok("Jogo atualizado com sucesso");

                
            }
            catch (Exception)
            {

                return BadRequest("Algo deu errado");
            }
        }
    }
}
