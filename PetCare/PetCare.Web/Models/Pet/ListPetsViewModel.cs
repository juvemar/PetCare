namespace PetCare.Web.Models.Pet
{
    using AutoMapper;

    using PetCare.Web.Infrastructure.Mapping;

    public class ListPetsViewModel : IMapFrom<PetCare.Models.Pet>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ImageId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ListPetsViewModel, PetCare.Models.Pet>("CreateHealthRecord")
                   .ForMember(m => m.ImageId, opts => opts.MapFrom(m => m.ImageId));
        }
    }
}