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

        private bool Can(string permission)
        {
            if (IsAdmin) {
                return true;
            }

            return Permissions.Contains(new UserPermission { Permission = "*" }) || Permissions.Contains(new UserPermission { Permission = permission });
        }

        public bool CanEditProperty(string property)
        {
            string PermissionString = "Edit " + property.ToLower();

            if (! UserPermission.AvailablePermissions.Contains(PermissionString)) {
                return false;
            }

            return Can(PermissionString);
        }

        public bool CanDeleteCharacter()
        {
            return Can("Delete Character");
        }

        public bool CanCreateCharacter()
        {
            return Can("Create Character");
        }
    }
}
