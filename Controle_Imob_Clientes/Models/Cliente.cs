using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Imob_Clientes.Models
{
    public class Cliente
    {

        public long? ClienteID { get; set; }
        public string Nome { get; set; }
        public long? CPF { get; set; }
        public string Casa { get; set; }
        public string Modalidade { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Required]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Required]
        public DateTime DataFim { get; set; }
        public string Observacoes { get; set; }

        public long? imobiliariaID { get; set; }
        public Imobiliaria Imobiliaria { get; set; }


    }
}
