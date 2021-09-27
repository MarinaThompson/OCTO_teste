using desafio_OCTO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_OCTO.Servico
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }
        public DbSet<PessoaFisica> ClientePessoaFisica { get; set; }
        public DbSet<PessoaJuridica> ClientePessoaJuridica { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet <Contato> Contatos { get; set; }
    }
}
