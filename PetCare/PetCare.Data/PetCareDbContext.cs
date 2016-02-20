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

        public virtual IDbSet<Event> Events { get; set; }

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
    //        modelBuilder.Entity<Pet>()
    //.HasMany(t => t.Events)
    //.WithMany(t => t.Pets);

    //        modelBuilder.Entity<Event>()
    //.HasMany(t => t.Pets)
    //.WithMany(t => t.Events);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
