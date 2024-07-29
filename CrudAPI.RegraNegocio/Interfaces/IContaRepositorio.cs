using CrudAPI.RegraNegocio.Models;

namespace CrudAPI.RegraNegocio.Interfaces
{
    public interface IContaRepositorio: IRepositorio<Conta>
    {
        Task<Conta> ObterPorId(int id);
    }
}
