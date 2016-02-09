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

        public User GetByUsername(string username)
        {
            return this.users.All().Where(u => u.UserName == username).FirstOrDefault();
        }

        //public void UpdateUser(string id, string username, string firstname, string lastname, string image)
        //{
        //    var currentUsr = this.users.GetById(id);
        //    currentUsr.UserName = username;
        //    currentUsr.Firstname = firstname;
        //    currentUsr.Lastname = lastname;
        //    currentUsr.PicturePath = image;
        //    this.users.Update(currentUsr);
        //    this.users.SaveChanges();
        //}
    }
}
