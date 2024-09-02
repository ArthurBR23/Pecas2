using Microsoft.EntityFrameworkCore;
using Pecas.Models;
namespace AutoPecas.Data
{
    public class AutoPecasContext : DbContext
    {
        public AutoPecasContext(DbContextOptions<AutoPecasContext> options): base (options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }
        public DbSet<Produto> Produto { get; set; }
    }
}
