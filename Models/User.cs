using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace App.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required, JsonIgnore]
        public string Password { get; set; }

        public bool IsAdmin { get; set; } = false;
        public IList<UserPermission> Permissions { get; set; }

        public bool HasPermissionTo(string perm)
        {
            if (IsAdmin) {
                return true;
            }

            perm = perm.ToLower();

            return
                UserPermission.AvailablePermissions.Contains(perm) &&
                Permissions.FirstOrDefault(p =>
                    p.Permission.ToLower().Equals("*") ||
                    p.Permission.ToLower().Equals(perm)
                ) != null;
        }
    }
}
