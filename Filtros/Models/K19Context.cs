using System.Data.Entity;

namespace Filtros.Models
{
    public class K19Context : DbContext
    {
        public K19Context() : base("K19")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<K19Context>());
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}