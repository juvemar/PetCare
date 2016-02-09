namespace PetCare.Services.Contracts
{
    using System.Linq;

    using PetCare.Models;

    public interface IImagesService
    {
        IQueryable<Image> GetAll();

        Image GetById(int id);
    }
}
