using CrudAPI.Dados.Context;
using CrudAPI.RegraNegocio.Interfaces;
using CrudAPI.RegraNegocio.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CrudAPI.Dados.Repositorio
{
    public abstract class Repositorio<TEntidadeBase> : IRepositorio<TEntidadeBase> where TEntidadeBase : EntidadeBase, new()
    {
        protected readonly ContextDB Db;
        protected readonly DbSet<TEntidadeBase> DbSet;

        protected Repositorio(ContextDB db)
        {
            Db = db;
            DbSet = db.Set<TEntidadeBase>();
        }

        //insert
        public async Task Adicionar(TEntidadeBase entidade)
        {
            DbSet.Add(entidade);
            await SaveChanges();
        }

        //Update
        public async Task Atualizar(TEntidadeBase entidade)
        {
            DbSet.Update(entidade);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntidadeBase>> Buscar(Expression<Func<TEntidadeBase, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
        //Busca todos os registros do DBSet atual
        public async Task<List<TEntidadeBase>> ObterTodos()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        //Delete
        public async Task Remover(TEntidadeBase entidade)
        {
            DbSet.Remove(entidade);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
    }
}
