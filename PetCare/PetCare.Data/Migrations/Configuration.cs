namespace PetCare.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using Common;
    public sealed class Configuration : DbMigrationsConfiguration<PetCareDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PetCareDbContext context)
        {
            context.Configuration.LazyLoadingEnabled = true;

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));

            userManager.PasswordValidator = new MinimumLengthValidator(5);

            if (!roleManager.RoleExists("admin"))
            {
                roleManager.Create(new IdentityRole("admin"));
            }

            if (!roleManager.RoleExists("vet"))
            {
                roleManager.Create(new IdentityRole("vet"));
            }

            if (!roleManager.RoleExists("user"))
            {
                roleManager.Create(new IdentityRole("user"));
            }

            var user = new User
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                PhoneNumber = "0888888888",
                FirstName = "Martin",
                LastName = "Atanasov"
            };

            if (userManager.FindByName("admin") == null)
            {
                var result = userManager.Create(user, "admin");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "admin");
                }
            }

            context.SaveChanges();
        }
    }
}
