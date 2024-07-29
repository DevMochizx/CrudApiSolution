using CrudAPI.RegraNegocio.Models;

namespace CrudAPI.RegraNegocio.Interfaces
{
    public interface IMovimentoContaRepositorio: IRepositorio<MovimentoConta>
    {
        Task<MovimentoConta> ObterPorId(int id);
    }
}
