using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            
           //Game Start
            Game();

           
        }
        //End of Main Function

        //Functions
        
        //Game Start Function
        static void Game()
        {
            //General Game Variables
            int round = 1;
            int turn = 1;

            
           
            //create player and enemy object
            Player Hero = new Player();
            Enemy Alduin = new Enemy();
            Hero.Health = 100;
         
            
            //Start
            ChangeText("Drem Yol Yok Dovakin.", "Greetings Dragonborn");
            //pause code(for effect)
            System.Threading.Thread.Sleep(2000);
            Console.Write("(Press Enter)");
            Console.ReadKey();
            Console.Clear();
            ChangeText("Fos Los Hin For Uld Hun", "What Is Your Name Mighty Hero?");
            Console.WriteLine();
            Hero.Name = Console.ReadLine();
            Console.Clear();

            //Game Intro
            Console.WriteLine(Hero.Name + " you are the mighty Dovakin or DragonBorn. After training you're self to be the hero the world needs you to be(and much ale)"
             + "You are ready to face the evil dragon Alduin. Though you a much smaller (and obviously not a huge fricken dragon). You have"
             + " The power of dragon shouts, courage and Skooma(Pretty much skyrim PCP)! During the fight you will have 4 abilities to choose from."
             + "If you're rage is high enough (goes up for every successfull attack) the dragon spirit is awoken in you and you can unleash,"
             + "a mighty shout on your enemy. The more rage you have, the more powerful your shout. You're next ability is you're trusty sword"
             + "though it doesn't hurt as much as a shout, its sturdy and realiable and can be used on every turn. On a more stratigic side, you"
             + "carry on you 4 bottles of health potion, and 2 of Skooma (your skooma dealer got busted). The health potions can heal for 30"
             + "HP and the skooma increase your atack damage for you're next turn by 30 (50 if its used before a shout). and your rage by 2");
            Console.WriteLine("To play press ENTER ");
            Console.ReadKey();
            Console.Clear();
            //Pick weapon
            Console.WriteLine("To start off your adventure, " + Hero.Name + " you must first pick out your weaponry. Each has different pros and cons so chose wisely");
            Console.WriteLine("(Press the coresponding letter next to a weapon then press enter to chose it)");
            Console.WriteLine("wh = warhammer: does 40 damage but only hits 70% of the time");
            Console.WriteLine("sw = sword: does 30 damage and hits 80% of the time");
            Console.WriteLine("dg = dagger: does 15 damage but hits 100% of the time");
            //Figure out weapon variable
            Hero.Weapon = Hero.ChooseWeapon(Console.ReadLine());
            
            //If weapon is invalid loop until it isnt
           
            while (Hero.Weapon == "Invalid")
            {
                Console.WriteLine("Invalid Choice, Pick Another Weapon");
                Hero.Weapon = Hero.ChooseWeapon(Console.ReadLine());
            }
            Console.Clear();

            ChangeText("Bo Nu Dovah Kiin Ahrk Luft Hin Paal!", "Go Now Dragonborn And Face Your Foe!");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            
            
           
            while (Hero.Health != 0 && Alduin.Health != 0)
            {
                //Basic Game Stats
                Console.WriteLine("Round: " + round);
                Console.WriteLine("Alduin's Health: " + Alduin.Health);
                Console.WriteLine("Alduins's Rage: " + Alduin.Health);
                Console.WriteLine("Your Health: " + Hero.Health);
                Console.WriteLine("Your Rage: " + Hero.Rage);
                Console.WriteLine();
                Console.WriteLine("Press Enter to Start next round");
                Console.ReadKey();
                //Heros Turn
                while (turn == 1 || Hero.InvalidMove)
                {

                    //player move 
                    Hero.ExecuteMove();
                    Alduin.Health -= Hero.Damage;
                    //set enemy turn and reset heros damage
                    turn = 2;
                    Hero.Damage = 0;
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                }


                //End of Heroes Turn

                //Enemy Turn
                if (turn == 2)
                {
                    Alduin.ExecuteMove();
                    Hero.Health -= Alduin.Damage;
                    Alduin.Damage = 0;
                    turn = 1;
                }
                //End of enemy turn

                //end of round
                round++;
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
            }

            //End of game
            if (Alduin.Health <= 0 && Hero.Health <= 0)
            {
                ChangeText("Lost grind yolus dinok nuz lost kuz hin paal voth hi! Nu hi fent velaaz ko mund do Sovengaurd ahrk joriin do keizaal fen dahmaan hi fah bok wah meyz!", "You have met a fierey death but have taken your foe with you! Now you shall feast in the halls of Sovengaurd and the people of skyrim will remember you for ages to come!");
            }
            else if (Alduin.Health <= 0)
            {
                ChangeText("Dovahkiin! Hi lost krinaan Alduin, sav keizaal ahrk lask hinmaar unahzaal praal ko Sovengaurd!", "Congradulations Dragonborn! You have slain Alduin, saved skyrim and earned yourself an eternal seat in Sovengaurd!");
                AddHighScore(turn);
            }
            else if (Hero.Health <= 0)
            {
                ChangeText("Not only have you been eaten alive, but you have left the world to be destroyed by Alduin!", "Not only have you been eaten alive, but you have left the world to be destroyed by Alduin!");
            }
            else
            {
                Console.WriteLine("Dude I have no idea what just happend..");
            }
            Console.ReadKey();
        }

        //Change Text Function
        //Changes text from the dragon tongue to english
        static void ChangeText(string firstText, string secondText)
        {
            
            for (int i = 0; i < firstText.Length; i++)
            {
                Console.Write(firstText[i]);
                System.Threading.Thread.Sleep(50);

            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(2000);
            for (int i = 0; i < secondText.Length; i++)
            {   
                Console.Write(secondText[i]);
                System.Threading.Thread.Sleep(50);
            }
         }

        //Add HighScores FUnction
        //Add highscore to list
        static void AddHighScore(int playerScore)
        {
            Console.WriteLine("Your Name: ");
            string playerName = Console.ReadLine();

            //create a gateway to database
            HighScoresEntities db = new HighScoresEntities();
            //create new highscore
            HighScore newHighScore = new HighScore();
            newHighScore.Date = DateTime.Now;
            newHighScore.Game = "Combat Simulator";
            newHighScore.Name = playerName;
            newHighScore.Score = playerScore;

            //add to database
            db.HighScores.Add(newHighScore);
        }
       
    }
}
