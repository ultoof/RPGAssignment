namespace Enemies
{
    // Super Class
    public abstract class Enemy
    {
        public string Name {get; set;}
        public int Health{get; set;}
        public int Damage{get; set;}

        public Enemy(string inputName = "Enemy", int inputHealth = 100, int inputDamage = 20)
        {
            Name = inputName;
            Health = inputHealth;
            Damage = inputDamage;
        }

        public abstract void TakeDamage(int damage);

        public virtual void Attack(Enemy target)
        {
            target.TakeDamage(Damage);
        }
    }

    public class Skeleton : Enemy
    {
        public Skeleton(string inputName = "Skeleton") : base(inputName){}

        public override void TakeDamage(int damage)
        {
            Health = Math.Max(Health - damage - 10, 0);
        }
    }

    public class Zombie : Enemy
    {
        public Zombie(string inputName = "Zombie") : base(inputName){}

        public override void TakeDamage(int damage)
        {
            Health = Math.Max(Health - damage/2, 0);
        }
    }

    public class Dragon : Enemy
    {
        private bool rage = false;

        public Dragon(string inputName = "Dragon") : base(inputName){}

        public override void TakeDamage(int damage)
        {
            Health = Math.Max(Health - damage, 0);
            rage = true;
        }

        public override void Attack(Enemy target)
        {
            int multi = rage ? 2 : 1;
            target.TakeDamage(Damage * multi);
        }
    }
}