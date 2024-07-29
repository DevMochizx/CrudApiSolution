using CrudAPI.RegraNegocio.Interfaces;
using CrudAPI.RegraNegocio.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.App.Controllers
{
    [Route("[controller]")]
    public class ContaController : Controller
    {
        IContaRepositorio _IContaRepositorio;
        public ContaController(IContaRepositorio iContaRepositorio)
        {
            _IContaRepositorio = iContaRepositorio;
        }

        [HttpGet("obter-todas")]
        public async Task<ActionResult<IEnumerable<Conta>>> ObterTodas()
        {
            var contas = await _IContaRepositorio.ObterTodos();
            return Ok(contas);
        }
        [HttpPost("incluir-conta")]
        public async Task<ActionResult<Conta>> Adicionar(Conta conta)
        {
            try
            {
                await _IContaRepositorio.Adicionar(conta);
                return Ok(conta);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("alterar-conta")]
        public async Task<ActionResult<Conta>> Atualizar([FromQuery] int id, [FromBody] Conta conta)
        {
            try
            {
                var contaAtual = await _IContaRepositorio.ObterPorId(id);

                if (contaAtual == null || contaAtual.Id == 0)
                {
                    return NotFound();
                }

                conta.Id = contaAtual.Id;
                await _IContaRepositorio.Atualizar(conta);

                return Ok(conta);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("excluir-conta")]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                var conta = await _IContaRepositorio.ObterPorId(id);

                if (conta == null || conta.Id == 0)
                {
                    return Ok();
                }

                await _IContaRepositorio.Remover(conta);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
