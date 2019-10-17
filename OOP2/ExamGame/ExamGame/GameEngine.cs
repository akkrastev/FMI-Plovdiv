using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGame
{
    class GameEngine
    {
        public Hero fighter {get;}
        public Hero defender { get; }

        public GameEngine(Hero fighter, Hero defender)
        {
            this.fighter = fighter;
            this.defender = defender;
        }
         
        public void StartTheGame()
        {
            Console.WriteLine("Welcome to the ARENA!");
            Console.WriteLine("In this game you get a generated hero that will fight other hero to the death.");
            Console.WriteLine("Good Luck!");
            Console.WriteLine();

            while(fighter.healthPoints > 0 && defender.healthPoints > 0)
            {
                int currentHealth1 = defender.healthPoints;

                fighter.Attack();
                defender.DefendAgainst(fighter.Attack());

                Console.WriteLine($"{fighter.Name} caused {currentHealth1 - defender.healthPoints} damage.");
                System.Threading.Thread.Sleep(1);

                if (fighter.healthPoints <= 0 || defender.healthPoints <= 0)
                {
                    break;
                }
                int currentHealth2 = fighter.healthPoints;
                defender.Attack();
                fighter.DefendAgainst(defender.Attack());
                Console.WriteLine($"{defender.Name} caused {currentHealth2 - fighter.healthPoints} damage.");

            }

            if(fighter.healthPoints > 0)
            {
                
                Console.WriteLine($"{fighter.Name} attacked {defender.Name}");
                Console.WriteLine($"{defender.Name} is dead !");
                Console.WriteLine($"{fighter.Name} is the winner !");
            }
            else
            {
                Console.WriteLine($"{defender.Name} attacked {fighter.Name}");
                Console.WriteLine($"{fighter.Name} is dead !");
                Console.WriteLine($"{defender.Name} is the winner !");
            }
            Console.WriteLine("Game ended !!!");

        }
    }
}
