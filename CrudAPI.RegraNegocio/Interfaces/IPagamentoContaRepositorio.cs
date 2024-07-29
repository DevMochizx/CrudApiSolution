using CrudAPI.RegraNegocio.Models;

namespace CrudAPI.RegraNegocio.Interfaces
{
    public interface IPagamentoContaRepositorio: IRepositorio<PagamentoConta>
    {
        Task<PagamentoConta> ObterPorId(int id);
    }
}
