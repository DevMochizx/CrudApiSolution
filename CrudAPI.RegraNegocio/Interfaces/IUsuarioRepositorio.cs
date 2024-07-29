using CrudAPI.RegraNegocio.Interfaces;
using CrudAPI.RegraNegocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.RegraNegocio.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
    
        Task<Usuario> ObterPorId(int id);
    }
}

