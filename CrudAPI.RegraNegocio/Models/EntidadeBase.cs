using System.ComponentModel.DataAnnotations;

namespace CrudAPI.RegraNegocio.Models
{
    public abstract class EntidadeBase
    {
        [Key]
        public int Id { get; set; }
    }
}
