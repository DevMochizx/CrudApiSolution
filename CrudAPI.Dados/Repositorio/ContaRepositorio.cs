using CrudAPI.Dados.Context;
using CrudAPI.RegraNegocio.Interfaces;
using CrudAPI.RegraNegocio.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Dados.Repositorio
{
    public class ContaRepositorio : Repositorio<Conta>, IContaRepositorio
    {
        public ContaRepositorio(ContextDB db) : base(db)
        {
        }
        public async Task<Conta> ObterPorId(int id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
        
    }
}
