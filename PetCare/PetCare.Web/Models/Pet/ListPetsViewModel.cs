using PetCare.Web.Infrastructure.Mapping;

namespace PetCare.Web.Models.Pet
{
    public class ListPetsViewModel : IMapFrom<PetCare.Models.Pet>
    {
        public string Name { get; set; }
    }
}