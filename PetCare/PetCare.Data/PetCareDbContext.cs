namespace PetCare.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Microsoft.AspNet.Identity.EntityFramework;

    using PetCare.Models;

    public class PetCareDbContext : IdentityDbContext<User>, IPetCareDbContext
    {
        public PetCareDbContext()
            : base("PetCareConnectionString", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Pet> Pets { get; set; }

        public virtual IDbSet<Species> Species { get; set; }

        public virtual IDbSet<Event> Events { get; set; }

        public virtual IDbSet<HealthRecord> HealthRecords { get; set; }

        public virtual IDbSet<VetVisit> VetVisits { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

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

            modelBuilder.Entity<Pet>()
    .HasRequired(a => a.HealthRecord)
    .WithMany()
    .HasForeignKey(a => a.HealthRecordId);

            modelBuilder.Entity<HealthRecord>()
                .HasOptional(b => b.Pet)
                .WithMany()
                .HasForeignKey(b => b.PetId);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
