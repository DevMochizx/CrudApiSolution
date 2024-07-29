using CrudAPI.RegraNegocio.Interfaces;
using CrudAPI.RegraNegocio.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.App.Controllers
{
    [Route("[controller]")]
    public class MovimentoContaController : Controller
    {
        IMovimentoContaRepositorio _IMovimentoContaRepositorio;
        public MovimentoContaController(IMovimentoContaRepositorio iMovimentoContaRepositorio)
        {
            _IMovimentoContaRepositorio = iMovimentoContaRepositorio;
        }

        [HttpGet("obter-todas")]
        public async Task<ActionResult<IEnumerable<MovimentoConta>>> ObterTodas()
        {
            var movimentoContas = await _IMovimentoContaRepositorio.ObterTodos();
            return Ok(movimentoContas);
        }

        [HttpPost("incluir-movimento-conta")]
        public async Task<ActionResult<MovimentoConta>> Adicionar(MovimentoConta movimentoConta)
        {
            try
            {
                await _IMovimentoContaRepositorio.Adicionar(movimentoConta);
                return Ok(movimentoConta);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("alterar-movimento-conta")]
        public async Task<ActionResult<MovimentoConta>> Atualizar([FromQuery] int id, [FromBody] MovimentoConta movimentoConta)
        {
            try
            {
                var movimentoContaAtual = await _IMovimentoContaRepositorio.ObterPorId(id);

                if (movimentoContaAtual == null || movimentoContaAtual.Id == 0)
                {
                    return NotFound();
                }

                movimentoConta.Id = movimentoContaAtual.Id;
                await _IMovimentoContaRepositorio.Atualizar(movimentoConta);

                return Ok(movimentoConta);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("excluir-movimento-conta")]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                var movimentoConta = await _IMovimentoContaRepositorio.ObterPorId(id);

                if (movimentoConta == null || movimentoConta.Id == 0)
                {
                    return Ok();
                }

                await _IMovimentoContaRepositorio.Remover(movimentoConta);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
