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

        DbSet<TEntity> IPetCareDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        public virtual IDbSet<Pet> Pets { get; set; }

        public virtual IDbSet<HealthRecord> HealthRecords { get; set; }

        public virtual IDbSet<VetVisit> VetVisits { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<VetBusyHour> VetBusyHours { get; set; }

        public virtual IDbSet<Notification> Notifications { get; set; }

        public virtual IDbSet<Room> Rooms { get; set; }

        public override IDbSet<User> Users { get; set; }

        public static PetCareDbContext Create()
        {
            return new PetCareDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
