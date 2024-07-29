using CrudAPI.RegraNegocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.RegraNegocio.Interfaces;

public interface IContaBancariaRepositorio : IRepositorio<ContaBancaria>
{
    Task<ContaBancaria> ObterPorId(int id);
}
