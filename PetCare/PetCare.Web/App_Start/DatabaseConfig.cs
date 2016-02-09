namespace PetCare.Web
{
    using System.Data.Entity;

    using PetCare.Data;
    using PetCare.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PetCareDbContext, Configuration>());
            PetCareDbContext.Create().Database.Initialize(true);
        }
    }
}