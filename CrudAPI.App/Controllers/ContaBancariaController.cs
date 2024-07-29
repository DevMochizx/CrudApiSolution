using CrudAPI.RegraNegocio.Interfaces;
using CrudAPI.RegraNegocio.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.App.Controllers

{
    [Route("[controller]")]
    public class ContaBancariaController : Controller
        {
        IContaBancariaRepositorio _IContaBancariaRepositorio;
            public ContaBancariaController(IContaBancariaRepositorio iContaBancariaRepositorio)
            {
                _IContaBancariaRepositorio = iContaBancariaRepositorio;
            }

            [HttpGet("obter-todas")]
            public async Task<ActionResult<IEnumerable<ContaBancaria>>> ObterTodas()
            {
                var ContaBancaria = await _IContaBancariaRepositorio.ObterTodos();
                return Ok(ContaBancaria);
            }

            [HttpPost("incluir-ContaBancaria")]
            public async Task<ActionResult<ContaBancaria>> Adicionar(ContaBancaria ContaBancaria)
            {
                try
                {
                    await _IContaBancariaRepositorio.Adicionar(ContaBancaria);
                    return Ok(ContaBancaria);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            [HttpPut("atualizar-ContaBancaria")]
            public async Task<ActionResult<ContaBancaria>> Atualizar([FromQuery] int id, [FromBody] ContaBancaria ContaBancaria)
            {
                try
                {
                    var ContaAtual = await _IContaBancariaRepositorio.ObterPorId(id);

                    if (ContaAtual == null || ContaAtual.Id == 0)
                    {
                        return NotFound();
                    }

                    ContaBancaria.Id = ContaAtual.Id;
                    await _IContaBancariaRepositorio.Atualizar(ContaBancaria);

                    return Ok(ContaBancaria);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpDelete("excluir-ContaBancaria")]
            public async Task<ActionResult> Deletar(int id)
            {
                try
                {
                    var ContaBancaria = await _IContaBancariaRepositorio.ObterPorId(id);

                    if (ContaBancaria == null || ContaBancaria.Id == 0)
                    {
                        return Ok();
                    }

                    await _IContaBancariaRepositorio.Remover(ContaBancaria);

                    return Ok();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }

