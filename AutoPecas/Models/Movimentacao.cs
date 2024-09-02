using System.ComponentModel.DataAnnotations;

namespace Pecas.Models
{
    public class Movimentacao
    {
        [Key]
        public long MovId { get; set; }
        public int QtdEntrada { get; set; }
        public int QtdSaida { get; set; }
    }
}