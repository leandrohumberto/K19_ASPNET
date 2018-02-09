namespace CustomizandoCodeFirstMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteraTelefoneFixoERenomeiaCelularDePessoa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pessoas", "TelefoneFixo", c => c.String(nullable: false));
            RenameColumn("dbo.Pessoas", "Celular", "TelefoneCelular");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pessoas", "TelefoneFixo", c => c.String());
            RenameColumn("dbo.Pessoas", "TelefoneCelular", "Celular");
        }
    }
}
