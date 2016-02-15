namespace PetCare.Services.Contracts
{
    using System.Linq;

    using Common;
    using PetCare.Models;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        User GetById(string id);

        IQueryable<User> GetByUsername(string username);

        void UpdateUser(string id, string username, string firstName, string lastName, string email, string phoneNumber, Image image);
    }
}
