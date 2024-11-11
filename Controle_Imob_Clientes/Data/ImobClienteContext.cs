using Controle_Imob_Clientes.Models;
using Controle_Imob_Clientes.Models.Infra;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Imob_Clientes.Data
{
    public class ImobClienteContext : IdentityDbContext<UsuarioDaAplicacao>
    {

        public ImobClienteContext(DbContextOptions<ImobClienteContext> options) : base(options)
        {
        }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Imobiliaria> Imobiliarias { get; set; }
        public DbSet<Administrador> Administradores{ get; set;}


    }
}
