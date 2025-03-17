using System.ComponentModel.DataAnnotations;

namespace AmbevTest.Domain.Entities
{
    public class Revenda
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }

    }

    public class Telefone
    {
        public int Id { get; set; }
        public int RevendaId { get; set; }
        public string Numero { get; set; }
    }

    public class Contato
    {
        public int Id { get; set; }
        public int RevendaId { get; set; }
        public string Nome { get; set; }
        public bool Principal { get; set; }

    }

    public class Endereco
    {
        public int Id { get; set; }
        public int RevendaId { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

    }


}
