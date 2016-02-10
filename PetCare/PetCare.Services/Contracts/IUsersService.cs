﻿namespace PetCare.Services.Contracts
{
    using PetCare.Models;
    using System.Linq;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        User GetById(string id);

        User GetByUsername(string username);

        //void UpdateUser(string id, string username, string firstname, string lastname, string image);
    }
}