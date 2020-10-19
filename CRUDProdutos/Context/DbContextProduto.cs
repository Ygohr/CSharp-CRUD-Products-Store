using CRUDProdutos.Models;
using System.Data.Entity;

namespace CRUDProdutos.Context
{
    public class DbContextProduto : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Promocao> Promocao { get; set; }
    }
}