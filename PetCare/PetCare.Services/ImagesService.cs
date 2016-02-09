namespace PetCare.Services
{
    using System.Linq;

    using Data.Repositories;
    using Models;
    using PetCare.Services.Contracts;

    public class ImagesService : IImagesService
    {
        private IRepository<Image> images;

        public ImagesService(IRepository<Image> images)
        {
            this.images = images;
        }

        public IQueryable<Image> GetAll()
        {
            return this.images.All();
        }

        public Image GetById(int id)
        {
            return this.images.GetById(id);
        }
    }
}
