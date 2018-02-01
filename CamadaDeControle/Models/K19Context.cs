using System.Data.Entity;

namespace CamadaDeControle.Models
{
    public class K19Context : DbContext
    {
        public K19Context() : base("K19")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<K19Context>());
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}