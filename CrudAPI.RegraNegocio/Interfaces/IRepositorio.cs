using CrudAPI.RegraNegocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.RegraNegocio.Interfaces
{
    public interface IRepositorio<TEntidadeBase> : IDisposable where TEntidadeBase : EntidadeBase
    {
        /// <summary>
        ///Apenas task método void 
        /// </summary>
        /// <param name="entidade">Objeto que herda de entidade que estiver instanciado no momento</param>
        /// <returns>Void</returns>
        Task Adicionar(TEntidadeBase entidade);

        /// <summary>
        ///tipo o task<List<TEntidadeBase>> retorna a lista do tipo passado
        /// </summary>
        /// <returns>Lista do Objeto do tipo entidade que etiver instanciado no momento</returns>
        Task<List<TEntidadeBase>> ObterTodos();

        /// <summary>
        ///Apenas task método void 
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        Task Atualizar(TEntidadeBase entidade);
        /// <summary>
        ///Apenas task método void
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        Task Remover(TEntidadeBase entidade);
        /// <summary>
        /// Executa consulta Lambda na entidade que herda de entidade que estiver instanciada no momento
        /// </summary>
        /// <param name="predicate">Expressão lambda que retorne true</param>
        /// <returns>tipo o task<IEnumerable<TEntidadeBase>> retorna a IEnumerable do tipo passado</returns>
        Task<IEnumerable<TEntidadeBase>> Buscar(Expression<Func<TEntidadeBase, bool>> predicate);

        /// <summary>
        /// Salva alterações
        /// </summary>
        /// <returns>Retorna quantidade de linhas afetadas </returns>
        Task<int> SaveChanges();
    }
}
