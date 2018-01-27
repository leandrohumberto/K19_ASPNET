using EF.Models;
using System.Data.Entity;

namespace EF
{
    class EfContext : DbContext
    {
        public DbSet<Editora> Editoras { get;set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Governador> Governadores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Consumidor> Consumidores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Ligacao> Ligacoes { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Jornal> Jornais { get; set; }

        public EfContext() : base("EF")
        {
            CustomDBInitializer initializer = new CustomDBInitializer();
            Database.SetInitializer(initializer);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Exemplo de como alterar o nome padrão de uma tabela de relacionamento "many-to-many"
            modelBuilder.Entity<Autor>()
                .HasMany(autor => autor.Livros)
                .WithMany(livro => livro.Autores)
                .Map(x =>
                {
                    x.ToTable("Livros_Autores");
                    x.MapLeftKey("Autor_Id");
                    x.MapRightKey("Livro_Id");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
