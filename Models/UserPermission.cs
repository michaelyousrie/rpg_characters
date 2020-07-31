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
        [Required]
        public string Permission { get; set; }

        public static String[] AvailablePermissions = {
            "delete character",
            "create character",
            "edit name",
            "edit hp",
            "edit hitpoints",
            "edit weapon",
            "edit height",
            "edit weight"
        };
    }
}
