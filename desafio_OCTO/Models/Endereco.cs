using System.ComponentModel.DataAnnotations;

namespace desafio_OCTO.Models
{
    public class Endereco
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Tipo de Endereço")]
        public string TipoEndereco { get; set; }

        [Required]
        public string Rua { get; set; }

        private string _cep; 

        [Required]
        public string CEP
        {
            get { return _cep; }
            set { _cep = value.Replace("-", string.Empty); }
        }

        [Required]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }
      
        public PessoaFisica PessoaFisica { get; set; }
        public int? PessoaFisicaID { get; set; }

        public PessoaJuridica PessoaJuridica { get; set; }
        public int? PessoaJuridicaID { get; set; }
    }
}