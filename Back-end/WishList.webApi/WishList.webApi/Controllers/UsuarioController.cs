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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);
            if (usuarioBuscado == null)
            {
                return NotFound("Nenhum usuario encontrado");
            }
            return Ok(usuarioBuscado);
        }

        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);
            if (usuarioBuscado != null)
            {
                try
                {
                    _usuarioRepository.Atualizar(id, usuarioAtualizado);
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
                { mensagem = "Usuario não encontrado." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
