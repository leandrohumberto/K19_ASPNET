namespace CodeFirstMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateLivro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Livros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EditoraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Editoras", t => t.EditoraId, cascadeDelete: true)
                .Index(t => t.EditoraId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livros", "EditoraId", "dbo.Editoras");
            DropIndex("dbo.Livros", new[] { "EditoraId" });
            DropTable("dbo.Livros");
        }
    }
}
