using CrudAPI.RegraNegocio.Interfaces;
using CrudAPI.RegraNegocio.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.App.Controllers
{
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        IUsuarioRepositorio _IUsuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio iUsuarioRepositorio)
        {
            _IUsuarioRepositorio = iUsuarioRepositorio;
        }

        [HttpGet("obter-usuario")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObterTodas()
        {
            var usuarios = await _IUsuarioRepositorio.ObterTodos();
            return Ok(usuarios);
        }

        [HttpPost("incluir-conta")]
        public async Task<ActionResult<Usuario>> Adicionar(Usuario usuario)
        {
            try
            {
                await _IUsuarioRepositorio.Adicionar(usuario);
                return Ok(usuario);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("alterar-usuario")]
        public async Task<ActionResult<Usuario>> Atualizar([FromQuery] int id, [FromBody] Usuario usuario)
        {
            try
            {
                var usuarioAtual = await _IUsuarioRepositorio.ObterPorId(id);

                if (usuarioAtual == null || usuarioAtual.Id == 0)
                {
                    return NotFound();
                }

                usuario.Id = usuarioAtual.Id;
                await _IUsuarioRepositorio.Atualizar(usuario);

                return Ok(usuario);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("excluir-usuario")]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                var usuario = await _IUsuarioRepositorio.ObterPorId(id);

                if (usuario == null || usuario.Id == 0)
                {
                    return Ok();
                }

                await _IUsuarioRepositorio.Remover(usuario);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
