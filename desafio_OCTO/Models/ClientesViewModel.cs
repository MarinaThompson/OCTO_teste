using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_OCTO.Models
{
    public class ClientesViewModel
    {
        public ICollection<PessoaJuridica> PessoasJuridicas { get; set; }
        public ICollection<PessoaFisica> PessoasFisicas { get; set; }
    }
}
