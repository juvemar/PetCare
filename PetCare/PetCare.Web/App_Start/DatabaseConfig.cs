using PetCare.Data;
using PetCare.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetCare.Web
{
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PetCareDbContext, Configuration>());
            PetCareDbContext.Create().Database.Initialize(true);
        }
    }
}   