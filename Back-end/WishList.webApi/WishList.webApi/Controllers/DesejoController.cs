using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList.webApi.Domains;
using WishList.webApi.Interfaces;
using WishList.webApi.Repositories;

namespace WishList.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DesejoController : ControllerBase
    {
        private IDesejoRepository _desejoRepository;
        public DesejoController()
        {
            _desejoRepository = new DesejoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_desejoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Desejo desejoBuscado = _desejoRepository.BuscarPorId(id);
            if(desejoBuscado == null)
            {
                return NotFound("Nenhum desejo encontrado");
            }
            return Ok(desejoBuscado);
        }

        [HttpPost]
        public IActionResult Post(Desejo novoDesejo)
        {
            try
            {
                _desejoRepository.Cadastrar(novoDesejo);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
           
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Desejo desejoAtualizado)
        {
            Desejo desejoBuscado = _desejoRepository.BuscarPorId(id);
            if(desejoBuscado != null)
            {
                try
                {
                    _desejoRepository.Atualizar(id, desejoAtualizado);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound
                (
                new
                { mensagem = "Desejo não encontrado." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _desejoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
