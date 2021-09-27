using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_OCTO.Models
{
   
    public class PessoaFisica
    {
        #region Propriedades 

        private string _cpf;

        [Key]
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Profissão")]
        public string Profissao { get; set; }

        [MinLength(11)]
        public string CPF
        {
            get { return _cpf; }
            set { _cpf = value.Replace(".", string.Empty).Replace("-", string.Empty); }
        }

        [Required]
        [MaxLength(10)]
        public string RG { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DataNascimento { get; set; }
      
        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        public virtual List<Endereco> Enderecos { get; set; }

        public virtual List<Contato> Contatos { get; set; }

        #endregion
    }
}
