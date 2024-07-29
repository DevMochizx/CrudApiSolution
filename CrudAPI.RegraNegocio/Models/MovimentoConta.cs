using System.ComponentModel.DataAnnotations.Schema;
using static CrudAPI.RegraNegocio.Utils.Enums;

namespace CrudAPI.RegraNegocio.Models
{
    [Table("MovimentoConta")]
    public class MovimentoConta: EntidadeBase
    {
        public int IdConta { get; set; }
        public EnTipoMovimento TipoMovimento { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorMovimento { get; set; }
        public int NumeroParcela { get; set; }
        public DateTime DataVencimento { get; set; }

    }
}
