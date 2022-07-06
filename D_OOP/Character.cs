using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_OOP
{
    public class Character
    {
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

        public void Hit(int damage)
        {
            health -= damage;
            Console.WriteLine(health);
        }
    }
}
