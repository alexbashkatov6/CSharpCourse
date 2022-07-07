using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_OOP
{
    public class Character
    {
        private const int speed = 10;
        private readonly int speed2;
        //public Character(string race)
        //{
        //    Race = race;
        //}
        public Character(Race race)
        {
            Race = race;
        }

        private int health = 100;

        public int Health
        {
            get 
            { 
                return health; 
            }
            private set 
            {
                health = value;
            }
        }

        //public string Race { get; private set; }
        public Race Race { get; private set; }

        public void Hit(int damage)
        {
            health -= damage;
            Console.WriteLine(health);
        }
    }
}
