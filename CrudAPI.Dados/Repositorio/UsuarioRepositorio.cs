using CrudAPI.Dados.Context;
using CrudAPI.RegraNegocio.Interfaces;
using CrudAPI.RegraNegocio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Dados.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ContextDB db) : base(db)
        {
        }

        public Task Adicionar(ContaBancaria usuario)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(ContaBancaria usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> ObterPorId(int id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

    }
}
