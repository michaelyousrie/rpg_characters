using System.ComponentModel.DataAnnotations;

namespace App.DTOs
{
    public class CreateCharacterRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int HP { get; set; }
        [Required]
        public int HitPoints { get; set; }
        [Required]
        public string Weapon { get; set; }
        [Required]
        public double height { get; set; }
        [Required]
        public int weight { get; set; }
    }
}
