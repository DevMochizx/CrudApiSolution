using CrudAPI.RegraNegocio.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Dados.Context
{
    public class ContextDB: IdentityDbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {

        }


        public DbSet<Conta> Contas { get; set; }
        public DbSet<MovimentoConta> MovimentoContas { get; set; }
        public DbSet<PagamentoConta> PagamentoContas { get; set; }
        public DbSet<ContaBancaria> ContaBancaria { get; set; }


    }
}
