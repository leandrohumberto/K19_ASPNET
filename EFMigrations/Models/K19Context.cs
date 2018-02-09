using System.Data.Entity;

namespace EFMigrations.Models
{
    public class K19Context : DbContext
    {
        public K19Context() : base("K19")
        {
        }

        public DbSet<Editora> Editoras { get; set; }
    }
}
