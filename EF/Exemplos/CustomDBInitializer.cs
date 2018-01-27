using System.Data.Entity;

namespace EF
{
    class CustomDBInitializer : DropCreateDatabaseIfModelChanges<EfContext>
    {
        protected override void Seed(EfContext context)
        {
            context.Database.ExecuteSqlCommand("ALTER TABLE Estados ADD CONSTRAINT governador UNIQUE(Governador_Id)");
            base.Seed(context);
        }
    }
}
