using System.Collections.Generic;
using App.Models;

namespace App.DTOs
{
    public class CharacterResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public IList<UserPermission> Permissions { get; set; }
    }
}
