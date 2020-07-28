namespace App.DTOs
{
    public class CharacterReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HP { get; set; } = 100;
        public int HitPoints { get; set; } = 10;
    }
}
