using System.ComponentModel.DataAnnotations;
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
    }
}
