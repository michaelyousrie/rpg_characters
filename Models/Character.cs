using System;

namespace App.Models
{
    public class Character : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HP { get; set; } = 100;
        public int HitPoints { get; set; } = 10;
        public string Weapon { get; set; } = "Sword";
        public double Height { get; set; } = 100.50;
        public int Weight { get; set; } = 60;

        public Character TakeDamage(int damage)
        {
            this.HP -= damage;

            if (this.HP <= 25) {
                this.HitPoints += this.HitPoints / 4;
            } else {
                this.HitPoints -= this.HitPoints / 10;
            }

            return this;
        }

        public bool CanTakeDamage(int damage)
        {
            return (this.HP > 0) && (this.HP >= damage);
        }
    }
}
