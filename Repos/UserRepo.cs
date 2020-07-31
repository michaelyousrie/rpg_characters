using System.Collections.Generic;
using System.Linq;
using App.Data;
using App.Helpers;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Repos
{
    public class UserRepo : IRepo<User>
    {
        private readonly MysqlContext _DB;

        public UserRepo(MysqlContext context)
        {
            _DB = context;
        }

        public User Search(string username, string password)
        {
            var user = GetByUsername(username);

            if (user == null ||!Hasher.Verify(password, user.Password)) {
                return null;
            }

            return user;
        }

        public User GetByUsername(string username)
        {
            return _DB.Users.FirstOrDefault(c => c.Username == username);
        }

        public override User Create(User user)
        {
            _DB.Users.Add(user);
            SaveChanges();

            return user;
        }

        public override void Delete(User user)
        {
            _DB.Users.Remove(user);
            SaveChanges();
        }

        public override void DeleteById(int id)
        {
            var user = GetById(id);
            Delete(user);
        }

        public override IEnumerable<User> GetAll()
        {
            return _DB.Users.Include(u => u.Permissions).ToList();
        }

        public override User GetById(int id)
        {
            return _DB.Users.Include(u => u.Permissions).FirstOrDefault(u => u.Id == id);
        }

        public override void Update(User user)
        {
            _DB.Users.Update(user);
            SaveChanges();
        }

        public override void SaveChanges()
        {
            _DB.SaveChanges();
        }
    }
}
