using AutoMapper.Configuration.Annotations;

namespace App.DTOs.Requests
{
    public class UpdateCharacterRequest
    {
        public string Name { get; set; } = null!;
        public int? HP { get; set; } = null;
        public int? HitPoints { get; set; } = null;
        public string Weapon { get; set; } = null;
        public double? Height { get; set; } = null;
        public int? Weight { get; set; } = null;
    }
}
