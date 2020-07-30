using System.Collections.Generic;
using App.Models;

namespace App.DTOs
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; } = false;
        public IList<UserPermission> Permissions { get; set; }
    }
}
