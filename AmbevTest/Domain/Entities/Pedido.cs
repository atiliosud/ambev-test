using System.ComponentModel.DataAnnotations;

namespace AmbevTest.Domain.Entities
{

    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RevendaId { get; set; }

        [Required]
        public DateTime DataPedido { get; set; } = DateTime.UtcNow;


    }

    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PedidoId { get; set; }

        [Required]
        public string Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }

    }

}
