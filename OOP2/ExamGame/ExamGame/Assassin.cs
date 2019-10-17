using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGame
{
   public class Assassin : Hero
    {
        private const int HIGHER_DAMEGE_CHANCE = 30;
        private const int HIGHER_DAMEGE_PERCENT = 300;

        public Assassin(string name, int attack, int defence, int health) : base(name, attack, defence, health)
        {

        }
        public override int Attack()
        {
            return HigherDamageAttack(HIGHER_DAMEGE_CHANCE, HIGHER_DAMEGE_PERCENT);
        }

        public override void DefendAgainst(int rawDamage)
        {
            DefaultDefence(rawDamage);
        }
    }
    
}
