namespace PetCare.Services.Contracts
{
    using System.Linq;

    using PetCare.Models;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        User GetById(string id);

        IQueryable<User> GetByUsername(string username);

        void UpdateUser(User user, string id);
    }
}
