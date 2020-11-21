using System;

namespace SimpleEvents
{
    public class Cat  // game object
    {
        private int health;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health  // if this reaches 0 we must redraw the game board and remove this particular dead cat
        {
            get => this.health;
            set
            {
                this.health = value;
                this.OnHealthChanged?.Invoke(this, this.health);  // if not null, invoke the event and send the information (info = which cat sends the event and the new health value)
            }
        }

        public event EventHandler<int> OnHealthChanged;
    }
}
