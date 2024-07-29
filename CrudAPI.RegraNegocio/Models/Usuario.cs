using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CrudAPI.RegraNegocio.Utils.Enums;

namespace CrudAPI.RegraNegocio.Models
{
    public class Usuario : EntidadeBase
    {
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
