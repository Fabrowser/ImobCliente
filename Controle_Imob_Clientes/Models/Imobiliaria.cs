using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Imob_Clientes.Models
{
    public class Imobiliaria
    {

        public long? imobiliariaID { get; set; }
        public string Nome{ get; set; }
        public string Endereco { get; set; }
        public long? Telefone { get; set; }
        public string Responsavel { get; set; }
        public string PaginaWeb { get; set; }
        public string PerfilInstagram { get; set; }

        public virtual ICollection<Cliente> Clientes{get; set;}

    }
}
