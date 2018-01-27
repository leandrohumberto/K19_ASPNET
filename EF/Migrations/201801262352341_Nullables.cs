namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nullables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Despesas", "Valor", c => c.Double());
            AlterColumn("dbo.Despesas", "Data", c => c.DateTime());
            AlterColumn("dbo.Receitas", "Valor", c => c.Double());
            AlterColumn("dbo.Receitas", "Data", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Receitas", "Data", c => c.DateTime(nullable: true));
            AlterColumn("dbo.Receitas", "Valor", c => c.Double(nullable: true));
            AlterColumn("dbo.Despesas", "Data", c => c.DateTime(nullable: true));
            AlterColumn("dbo.Despesas", "Valor", c => c.Double(nullable: true));
        }
    }
}
