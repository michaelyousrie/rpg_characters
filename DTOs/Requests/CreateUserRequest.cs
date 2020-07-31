using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.DTOs.Requests
{
    public class CreateUserRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
        public IList<CreateUserPermissionRequest> Permissions { get; set; }
    }
}
