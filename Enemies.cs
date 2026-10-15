namespace Enemies
{
    // Super Class
    public abstract class Enemy
    {
        // Properties
        public string Name {get; set;}
        public int Health{get; set;}
        public int Damage{get; set;}

        // Constructor
        public Enemy(string inputName = "Enemy", int inputHealth = 100, int inputDamage = 20)
        {
            Name = inputName;
            Health = inputHealth;
            Damage = inputDamage;
        }

        // Base take damage function
        public abstract void TakeDamage(int damage, string damageType);

        // Base attack function
        public virtual void Attack(Enemy target)
        {
            target.TakeDamage(Damage, "");
        }
    }

    public class Skeleton : Enemy
    {
        public Skeleton(string inputName = "Skeleton", int inputHealth = 100, int inputDamage = 20) : base(inputName, inputHealth, inputDamage){}

        // Takes 10 less than the damage dealt, also makes sure that the skeleton cant heal by taking negative damage.
        public override void TakeDamage(int damage, string damageType)
        {
            Health = Math.Max(Health - Math.Max(damage - 10, 0), 0);
        }
    }

    public class Zombie : Enemy
    {
        public Zombie(string inputName = "Zombie", int inputHealth = 100, int inputDamage = 20) : base(inputName, inputHealth, inputDamage){}

        // Takes half of the damage dealt
        public override void TakeDamage(int damage, string damageType)
        {
            Health = Math.Max(Health - damage/2, 0);
        }
    }

    public class Dragon : Enemy
    {
        public bool rage {get; private set;}

        public Dragon(string inputName = "Dragon", int inputHealth = 100, int inputDamage = 20) : base(inputName, inputHealth, inputDamage){}

        // Takes extra damage if damageType is Ice, also enables rage
        public override void TakeDamage(int damage, string damageType)
        {
            int multi = damageType == "Ice" ? 2 : 1;
            rage = true;
            Health = Math.Max(Health - damage * multi, 0);
        }

        // Deals extra damage if rage is true
        public override void Attack(Enemy target)
        {
            int multi = rage ? 2 : 1;
            target.TakeDamage(Damage * multi, "");
        }
    }

    public class IceGuy : Enemy
    {
        private string damageType = "Ice";

        public IceGuy(string inputName = "IceGuy", int inputHealth = 100, int inputDamage = 20) : base(inputName, inputHealth, inputDamage){}

        public override void TakeDamage(int damage, string damageType)
        {
            Health = Math.Max(Health - damage, 0);
        }

        public override void Attack(Enemy target)
        {
            target.TakeDamage(Damage, damageType);
        }
    }
}