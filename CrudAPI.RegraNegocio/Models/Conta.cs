using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CrudAPI.RegraNegocio.Utils.Enums;

namespace CrudAPI.RegraNegocio.Models
{
    //data annotation
    [Table("Conta")]
    public class Conta: EntidadeBase
    {
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
        public EnTipoConta TipoConta { get; set; }
        public int QuantidadeParcelas { get; set; }

    }
}
