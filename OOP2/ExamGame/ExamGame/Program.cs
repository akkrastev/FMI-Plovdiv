using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Hero angel = new Monk("angel", 60, 20, 500);
            Hero stoqn = new Assassin("stoqn", 50, 20, 500);
            GameEngine game = new GameEngine(angel, stoqn);
            game.StartTheGame();

        }
    }
}
