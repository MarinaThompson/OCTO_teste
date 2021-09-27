using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_OCTO.Models
{
   
    public class PessoaJuridica
    {
        #region Propriedades 
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }


        [Required]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        private string _cnpj;

        [Required]
        [MinLength(14)]
        public string CNPJ 
        {
            get { return _cnpj; }
            set { _cnpj = value.Replace(".", string.Empty).Replace("/", string.Empty).Replace("-", string.Empty); }
        }

        [Required]
        [Display(Name = "Data de Abertura")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataAbertura { get; set; }
        public virtual List<Endereco> Enderecos { get; set; }

        public virtual List<Contato> Contatos { get; set; }

        #endregion
    }
}
