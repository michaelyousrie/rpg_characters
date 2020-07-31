using System.Collections.Generic;
using App.Models;

namespace App.DTOs.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public IList<UserPermissionResponse> Permissions { get; set; }
    }
}
