using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class UserPermission : IModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string Permission { get; set; } = "*";

        public static String[] AvailablePermissions = {
            "Delete Character",
            "Create Character",

            "Edit name",
            "Edit hp",
            "Edit hitpoints",
            "Edit weapon",
            "Edit height",
            "Edit weight"
        };
    }
}
