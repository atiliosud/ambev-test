using System.ComponentModel.DataAnnotations;

namespace AmbevTest.Models.Pedido
{
    public class CriarPedidoRequest
    {
        [Required(ErrorMessage = "RevendaId é obrigatória.")]
        public int RevendaId { get; set; }

        [Required(ErrorMessage = "Items é obrigatório.")]
        public List<Produtos> Items { get; set; }
    }

    public class Produtos
    {
        [Required(ErrorMessage = "Produto é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Produto deve ter entre 2 e 100 caracteres.")]
        public string Produto { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatória.")]
        public int Quantidade { get; set; }
    }
}
