using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.RegraNegocio.Models
{
    [Table("ContaBancaria")]
    public class ContaBancaria : EntidadeBase
{   public string Banco {  get; set; }
    public string Agencia { get; set; }   
     public string Conta {  get; set; }
}
}
