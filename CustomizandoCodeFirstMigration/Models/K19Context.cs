using System.Data.Entity;

namespace CustomizandoCodeFirstMigration.Models
{
    public class K19Context : DbContext
    {
        public K19Context() : base("K19")
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
