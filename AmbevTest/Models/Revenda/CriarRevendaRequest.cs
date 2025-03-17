using AmbevTest.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace AmbevTest.Models.Revenda
{
    public class CriarRevendaRequest
    {
        [Required(ErrorMessage = "CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "CNPJ inválido. Deve conter exatamente 14 dígitos.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Razão Social é obrigatória.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Razão Social deve ter entre 2 e 100 caracteres.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Nome Fantasia é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Nome Fantasia deve ter entre 2 e 100 caracteres.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }


        public List<String> Telefones { get; set; } = new();

        [Required(ErrorMessage = "Nome de Contato é obrigatório.")]
        public List<ContatoDaRevenda> Contatos { get; set; } = new();

        [Required(ErrorMessage = "Endereço de Entrega é obrigatório.")]
        public List<EnderecosDeEntrega> EnderecosDeEntrega { get; set; } = new();
    }

    public class EnderecosDeEntrega
    {
        [Required(ErrorMessage = "Rua é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Rua deve ter entre 2 e 100 caracteres.")]
        public string Rua { get; set; }


        [Required(ErrorMessage = "Número é obrigatório.")]
        public string Numero { get; set; }


        [Required(ErrorMessage = "Bairro é obrigatório.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Bairro deve ter entre 2 e 50 caracteres.")]
        public string Bairro { get; set; }


        [Required(ErrorMessage = "Cidade é obrigatório.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Cidade deve ter entre 2 e 50 caracteres.")]
        public string Cidade { get; set; }


        [Required(ErrorMessage = "Estado é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Estado deve ter 2 caracteres.")]
        public string Estado { get; set; }


        [Required(ErrorMessage = "CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP inválido.")]
        public string Cep { get; set; }
    }

    public class ContatoDaRevenda
    {
        [Required(ErrorMessage = "Nome do contato é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Nome do contato deve ter entre 2 e 100 caracteres.")]
        public string Nome { get; set; }

        [Required]
        public bool Principal { get; set; }
    }
}