using CrudAPI.Dados.Context;
using CrudAPI.RegraNegocio.Interfaces;
using CrudAPI.RegraNegocio.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Dados.Repositorio
{
    public class PagamentoContaRepositorio : Repositorio<PagamentoConta>, IPagamentoContaRepositorio
    {
        public PagamentoContaRepositorio(ContextDB db) : base(db)
        {
        }

        public async Task<PagamentoConta> ObterPorId(int id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
