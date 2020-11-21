using System;

namespace SimpleEvents
{
    // events allow you to subscribe for changes and receive a notification when that change happens

    // in the example we want to get notified when cat health drops to 0
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello cats!");
            Console.WriteLine();

            var cat = new Cat
            {
                Id = 1,
                Name = "catzilla",
                Health = 100
            };

            cat.OnHealthChanged += CatOnHealthChanged;
            cat.OnHealthChanged += CatIsDead;

            cat.Health = 200;  // catzilla has new health: 200
            cat.Health = 40;   // catzilla has new health: 40
            cat.Health = 0;    // catzilla has new health: 0 + The cat catzilla is no longer alive ...
            cat.Health = 100;  // catzilla has new health: 100
            cat.Health = 50;   // catzilla has new health: 50
            cat.Health = 0;    // catzilla has new health: 0 + The cat catzilla is no longer alive ...
        }

        private static void CatIsDead(object sender, int health)
        {
            var cat = sender as Cat;
            if (cat.Health <= 0)
                Console.WriteLine($"The cat {cat.Name} is no longer alive ...");
        }

        private static void CatOnHealthChanged(object sender, int health)
        {
            var cat = sender as Cat;
            Console.WriteLine($"{cat.Name} has new health: {health}");
        }
    }
}
