using System.Data.Entity;

namespace Validacao.Models
{
    public class K19Context : DbContext
    {
        public K19Context() : base("K19")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<K19Context>());
        }

        public DbSet<Jogador> Jogadores { get; set; }
    }
}