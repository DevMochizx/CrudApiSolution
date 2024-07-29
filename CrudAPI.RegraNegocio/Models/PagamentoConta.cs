using System.ComponentModel.DataAnnotations.Schema;

namespace CrudAPI.RegraNegocio.Models
{
    [Table("PagamentoConta")]
    public class PagamentoConta: EntidadeBase
    {
        public int IdMovimentoConta { get; set; }
        public int NumeroParcela { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorMovimento { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorPago { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorJuros { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorDesconto { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
