using AmbevTest.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace AmbevTest.Models.Revenda
{
    public class RetornoRevenda
    { 
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public List<Telefone> Telefones { get; set; } = new List<Telefone>();
        public List<Contato> NomesContato { get; set; } = new List<Contato>();
        public List<Endereco> EnderecosEntrega { get; set; } = new List<Endereco>();
    }

}
