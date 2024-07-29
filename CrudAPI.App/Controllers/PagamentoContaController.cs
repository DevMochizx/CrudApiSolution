using CrudAPI.RegraNegocio.Interfaces;
using CrudAPI.RegraNegocio.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.App.Controllers
{
    [Route("[controller]")]
    public class PagamentoContaController : Controller
    {
        IPagamentoContaRepositorio _IPagamentoContaRepositorio;
        public PagamentoContaController(IPagamentoContaRepositorio iPagamentoContaRepositorio)
        {
            _IPagamentoContaRepositorio = iPagamentoContaRepositorio;
        }

        [HttpGet("obter-todas")]
        public async Task<ActionResult<IEnumerable<PagamentoConta>>> ObterTodas()
        {
            var PagamentoContas = await _IPagamentoContaRepositorio.ObterTodos();
            return Ok(PagamentoContas);
        }

        [HttpPost("incluir-pagamento-conta")]
        public async Task<ActionResult<PagamentoConta>> Adicionar(PagamentoConta pagamentoConta)
        {
            try
            {
                await _IPagamentoContaRepositorio.Adicionar(pagamentoConta);
                return Ok(pagamentoConta);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("alterar-pagamento-conta")]
        public async Task<ActionResult<PagamentoConta>> Atualizar([FromQuery] int id, [FromBody] PagamentoConta pagamentoConta)
        {
            try
            {
                var PagamentoContaAtual = await _IPagamentoContaRepositorio.ObterPorId(id);

                if (PagamentoContaAtual == null || PagamentoContaAtual.Id == 0)
                {
                    return NotFound();
                }

                pagamentoConta.Id = PagamentoContaAtual.Id;
                await _IPagamentoContaRepositorio.Atualizar(pagamentoConta);

                return Ok(pagamentoConta);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("excluir-pagamento-conta")]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                var pagamentoConta = await _IPagamentoContaRepositorio.ObterPorId(id);

                if (pagamentoConta == null || pagamentoConta.Id == 0)
                {
                    return Ok();
                }

                await _IPagamentoContaRepositorio.Remover(pagamentoConta);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
