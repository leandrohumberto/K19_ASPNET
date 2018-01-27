using EF.Models;
using System.Data.Entity;

namespace EF.Contexts
{
    class GranaContext : DbContext
    {
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }

        public GranaContext() : base("EF")
        {
            DropCreateDatabaseIfModelChanges<EfContext> initializer = new DropCreateDatabaseIfModelChanges<EfContext>();
            Database.SetInitializer(initializer);
        }
    }
}
