using System.Collections.Generic;
using App.DTOs.Requests;
using App.DTOs.Responses;
using App.Models;

namespace App.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user);
        User GetByUsername(string username);
    }
}
