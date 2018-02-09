namespace CodeFirstMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTelefoneToEditora : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Editoras", "Telefone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Editoras", "Telefone");
        }
    }
}
