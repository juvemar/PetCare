namespace PetCare.Services.Contracts
{
    using PetCare.Models;
    using System.Linq;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        User GetById(string id);

        IQueryable<User> GetByUsername(string username);

        void UpdateUser(string id, string username, string firstName, string lastName, string email, string gender, string phoneNumber, Image image);
    }
}
