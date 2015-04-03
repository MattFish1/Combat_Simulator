using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_Simulator
{
    enum Move
    {
        HealthPotion,
        Skooma,
        Weapon,
        Shout
    }
    enum WeaponType
    {
        Warhammer,
        Sword,
        Dagger
    }
    class Player
    {
       //PROPERTIES
        
        //Health
        private int _health = 100;

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        
        
        //Is alive bool
        private bool _isAlive = true;

        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }
        
        //rage
        private int _rage;

        public int Rage
        {
            get { return _rage; }
            set { _rage = 0; }
        }
        
        
        //damage
        public int Damage { get; set; }
        

        //name
        public string Name { get; set; }

        //health potions
        private int _healthPotions=4;

        public int HealthPotions
        {
            get { return  _healthPotions; }
            set {  _healthPotions = 4; }
        }
        
        //skooma
        private int _skooma;

        public int Skooma
        {
            get { return _skooma; }
            set { _skooma = 2; }
        }
        

        //skooma used bool
        private bool _skoomaUsed;

        public bool SkoomaUsed
        {
            get { return _skoomaUsed; }
            set { _skoomaUsed = false; }
        }

        //invalid move
        private bool _invalidMove;

        public bool InvalidMove
        {
            get { return _invalidMove; }
            set { _invalidMove = false; }
        }
        

        //Weapon
        private string _weapon;

        public string Weapon
        {
            get { return _weapon; }
            set { _weapon = value.ToString(); }
        }
        
        //Move
        private string _playerMove;

        public string PlayerMove
        {
            get { return _playerMove; }
            set { _playerMove = value.ToString(); }
        }
        
        
      //CONSTRUCTOR
        
	
      //METHODS
        //Execute Move
        public void ExecuteMove()
        {
            Console.Clear();
            //Pick move
            Console.WriteLine("Pick Your Move");
            Console.WriteLine();
            Console.WriteLine("S: Shout ");
            if (this.Rage < 4)
            {
                Console.Write("(not enough rage!)");
            }
            else
            {
                Console.WriteLine("(Rage: " + this.Rage);
            }
            Console.WriteLine();
            Console.WriteLine("W: " + this.Weapon);
            Console.WriteLine("H :Health Potion " + this.HealthPotions);
            if (this.HealthPotions <= 0)
            {
                Console.Write(" (out of potions)");
            }
            Console.WriteLine("SK: Skooma: " + this.Skooma);
            if (this.Skooma <= 0)
            {
                Console.Write(" (out of skooma)");
            }
            Console.WriteLine();

            this.PlayerMove = Console.ReadLine();

            Console.Clear();
            //If skooma was used last round add damage
            if (this.SkoomaUsed == true)
            {
                this.Damage += 30;
            }
            
          //Execute move

            //Shout
            if (this.PlayerMove == "S" && this.Rage < 4)
            {
                //If skooma was used last round add damage
                if (this.SkoomaUsed == true)
                {
                    this.Damage += 50;
                }
                this.Damage += 30 * this.Rage;
                this.Rage = 0;
                Console.WriteLine("You're mighty shout did " + this.Damage + " damage!");
                this.SkoomaUsed = false;
            }

            //Weapon
            else if (this.PlayerMove == "W")
            {

                this.Damage += WeaponDamage(this.Weapon);
               
                if (this.Damage > 0)
                {
                    this.Rage++;
                    //If skooma was used last round add damage
                    if (this.SkoomaUsed == true)
                    {
                        this.Damage += 30;
                    }
                    Console.WriteLine("Your " + this.Weapon + " did " + this.Damage + " damage.");
                }
                else
                {
                    Console.WriteLine("Your " + this.Weapon + " missed.");
                }

                this.SkoomaUsed = false;
                this.InvalidMove = false;
            }

            //Health Potion
            else if (this.PlayerMove == "H" && this.HealthPotions > 0)
            {
                this.Health += 30;
                Console.WriteLine("You healed yourself for 30 hp!");
                this.HealthPotions--;
                this.InvalidMove = false;
            }
            //Skooma
            else if (this.PlayerMove == "SK" && this.Skooma > 0)
            {
                this.SkoomaUsed = true;
                Console.WriteLine("Your Skooma gave you strength");
                this.Skooma--;
                this.InvalidMove = false;
            }
            else
            {
                Console.WriteLine("Invalid Move");
                this.InvalidMove = true;
            }
        }
        //End of Execute Move Method
        
        //Choose Weapon Method
        //wh = warhammer: does 50 damage but only hits 70% of the time
        //sw = sword: does 40 damage and hits 80% of the time
        //dg = dagger: does 15 damage but hits 100% of the time
           
        public string ChooseWeapon(string weapon)
        {

            if (weapon == "wh")
            {
                return "WarHammer";
            }
            else if (weapon == "sw")
            {
                return "Sword";
            }
            else if (weapon == "dg")
            {
                return "Dagger";
            }
            else
            {
                return "Invalid";
            }
        }
        //End of Choose Weapon Method

        //Weapon Damage Method
        public int WeaponDamage(string weapon)
        {
            //Chance
            Random rnd = new Random();
            int chance = rnd.Next(1, 10);
            int damage = 0;

            if (weapon == "WarHammer")
            {
                if (chance <= 7)
                {
                    damage = 40;
                }
            }
            else if (weapon == "Sword")
            {
                if (chance <= 8)
                {
                    damage = 30;
                }
            }
            else
            {
                damage = 15;
            }
            return damage;

        }
        //End of Weapon Damage Method

    }
}
