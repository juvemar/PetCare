namespace PetCare.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using PetCare.Models;

    public class PetCareDbContext : IdentityDbContext<User>, IPetCareDbContext
    {
        public PetCareDbContext()
            : base("PetCareConnectionString", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Pet> Pets { get; set; }

        public virtual IDbSet<Event> Events { get; set; }

        public virtual IDbSet<HealthRecord> HealthRecords { get; set; }

        public virtual IDbSet<VetVisit> VetVisits { get; set; }

        public override IDbSet<User> Users { get; set; }

        public static PetCareDbContext Create()
        {
            return new PetCareDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
    .HasMany(t => t.Events)
    .WithMany(t => t.Pets);

            modelBuilder.Entity<Event>()
    .HasMany(t => t.Pets)
    .WithMany(t => t.Events);

            base.OnModelCreating(modelBuilder);
        }
    }
}
