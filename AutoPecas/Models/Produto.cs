using System.ComponentModel.DataAnnotations;

namespace Pecas.Models
{
    public class Produto
    {
        [Key]
        public int ProdId { get; set; }

        public string Nome { get; set; }

        public string Categoria { get; set; }

        public string Marca { get; set; }

        public int Valor { get; set; }

        public int Quantidade { get; set; }
    }
}