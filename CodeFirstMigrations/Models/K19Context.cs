using System.Data.Entity;

namespace CodeFirstMigrations.Models
{
    class K19Context : DbContext
    {
        public K19Context() : base("K19")
        {
        }

        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}
