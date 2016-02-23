namespace PetCare.Web.Areas.Administrator.Models.User
{
    using PetCare.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<PetCare.Models.User>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsVet { get; set; }

        public string SergeryLocation { get; set; }
    }
}