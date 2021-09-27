using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_OCTO.Models
{
    public class Contato
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Tipo de Contato")]
        public string TipoContato  { get; set; }

        private string _numero;

        [Required]
        [Display(Name = "Número")]
        [MaxLength(15)]
        public string Numero 
        {
            get { return _numero; }
            set { _numero = value.Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty); }
        }

        public PessoaFisica PessoaFisica { get; set; }
        public int? PessoaFisicaID { get; set; }

        public PessoaJuridica PessoaJuridica { get; set; }
        public int? PessoaJuridicaID { get; set; }
    }
}
