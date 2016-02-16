namespace PetCare.Services
{
    using System.Linq;

    using Data.Repositories;
    using PetCare.Models;
    using PetCare.Services.Contracts;

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

        public void UpdateUser(User user, string id)
        {
            var currentUser = this.users.GetById(id);
            currentUser.UserName = user.UserName == null ? currentUser.UserName : user.UserName;
            currentUser.FirstName = user.FirstName == null ? currentUser.FirstName : user.FirstName;
            currentUser.LastName = user.LastName == null ? currentUser.LastName : user.LastName;
            currentUser.Email = user.Email == null ? currentUser.Email : user.Email;
            currentUser.PhoneNumber = user.PhoneNumber == null ? currentUser.PhoneNumber : user.PhoneNumber;
            currentUser.ProfilePicture = user.ProfilePicture == null ? currentUser.ProfilePicture : user.ProfilePicture;

            this.users.Update(currentUser);
            this.users.SaveChanges();
        }
    }
}
