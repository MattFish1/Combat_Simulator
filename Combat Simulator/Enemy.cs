using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_Simulator
{
    class Enemy
    {
        //PROPERTIES
        //health
       
        private int _health = 100;

        public int Health
        {
            get { return _health ; }
            set { _health = 100; }
        }

        //rage
        int enemyRage = 0;
        private int _rage;

        public int Rage
        {
            get { return _rage; }
            set { _rage = 0; }
        }

        //damage
        public int Damage { get; set; }

        //move
        public string Move { get; set; }

        //METHODS

        //Turn function
        public void ExecuteMove()
        {
            //enemy's ability's
            //fireball - does a lot of damage but has a 70% chance of hitting
            //shout - very strong ability but can only be used if Alduins "RAGE" is full, also has a 70% chance of hitting
            //bite-week attack but always hits

            //Decide Move

            //rand int to decide which attack is used
            Random rnd = new Random();
            int move = rnd.Next(1, 4);
            int chance = rnd.Next(1, 10);
            //shout
            if (this.Rage > 3 && move == 3)
            {
                //70% chance of hitting
                if (chance <= 7)
                {
                    this.Move = "shout";
                }
                //attack failed
                else
                {
                    this.Move = "failled";
                }

            }
            // fireball
            else if (move == 1)
            {
                //70% chance of hitting
                if (chance <= 7)
                {
                    this.Move = "fireball";
                }
                //attack failled
                else
                {
                    this.Move = "failled";
                }
            }
            //bite
            else
            {
                this.Move = "bite";
            }

            //execute move
            if (this.Move == "fireball")
            {
                this.Damage = 30;
                Console.WriteLine("Enemy Fireball did 30 damage!");
            }
            else if (this.Move == "shout")
            {
                this.Damage= 30 * this.Rage;
                Console.WriteLine("Enemy Shout did " + 30 * enemyRage + " damage!");
                enemyRage = 0;
            }
            else if (this.Move == "bite")
            {
                this.Damage = 20;
                Console.WriteLine("The enemy Bit you for 20 damage");
            }
            else
            {
                Console.WriteLine("Enemy Attack Failed!");
            }
        }

        
    }
}
