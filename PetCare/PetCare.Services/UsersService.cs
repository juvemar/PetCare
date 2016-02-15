namespace PetCare.Services
{
    using System.Linq;

    using Data.Repositories;
    using PetCare.Models;
    using PetCare.Services.Contracts;
    using Common;
    public class UsersService : IUsersService
    {
        private IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public User GetById(string id)
        {
            return this.users.GetById(id);
        }

        public IQueryable<User> GetByUsername(string username)
        {
            return this.users.All().Where(u => u.UserName == username).AsQueryable();
        }

        public void UpdateUser(string id, string username, string firstName, string lastName, string email, string phoneNumber, Image image)
        {
            var currentUser = this.users.GetById(id);
            currentUser.UserName = username == null ? currentUser.UserName : username;
            currentUser.FirstName = firstName == string.Empty ? currentUser.FirstName : firstName;
            currentUser.LastName = lastName == string.Empty ? currentUser.LastName : lastName;
            currentUser.Email = email == string.Empty ? currentUser.Email : email;
            currentUser.PhoneNumber = phoneNumber == string.Empty ? currentUser.PhoneNumber : phoneNumber;
            currentUser.ProfilePicture = image == null ? currentUser.ProfilePicture : image;

            this.users.Update(currentUser);
            this.users.SaveChanges();
        }
    }
}
