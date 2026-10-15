using Enemies;

// Variables
Skeleton skeleton = new Skeleton("Skeleton",100,50);
Zombie zombie = new Zombie("Zombieguy",200,20);
Dragon dragon = new Dragon("dragonde",1000,20);
IceGuy iceGuy = new IceGuy("Ice",50,20);

// Runtime for test
zombie.Attack(skeleton);
Console.Clear();
Console.WriteLine($"Skeleton health {skeleton.Health}"); // Should print 90, takes 10 less damage than given, 100 - 10 = 90

skeleton.Attack(zombie);
Console.WriteLine($"Zombie health {zombie.Health}"); // Should print 175, takes half damage of 50, 200 - 25 = 175

skeleton.Attack(dragon);
Console.WriteLine($"Dragon health {dragon.Health}, Dragon rage is {dragon.rage}"); // should print 950 and true, 1000 - 50 = 950

dragon.Attack(skeleton);
Console.WriteLine($"Skeleton health {skeleton.Health}"); // Should print 60, double damage and -10, 90 - (40-10) = 60

iceGuy.Attack(dragon);
Console.WriteLine($"Dragon health {dragon.Health}, Dragon rage is {dragon.rage}"); // should print 910 and true, takes 20*2 due to ice weakness