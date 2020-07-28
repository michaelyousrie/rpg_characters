namespace App.Models
{
    public class Character : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HP { get; set; } = 100;
        public int HitPoints { get; set; } = 10;

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
