namespace PetCare.Web.Areas.Administrator.Models.HealthRecord
{
    using PetCare.Web.Infrastructure.Mapping;

    public class HealthRecordAdminViewModel : IMapFrom<PetCare.Models.HealthRecord>
    {
        public int PetId { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public string FurColor { get; set; }

        public string Coat { get; set; }
    }
}