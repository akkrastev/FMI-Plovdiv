using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGame
{
   public class Elf : Hero
    {
        private const int HIGHER_DAMEGE_CHANCE = 40;
        private const int HIGHER_DAMEGE_PERCENT = 300;
        private const int HIGHER_DEFFENCE_CHANCE = 15;
        private const int HIGHER_DEFFENCE_PERCENT = 150;

        public Elf(string name, int attack, int defence, int health) : base(name, attack, defence, health)
        {

        }

        public override int Attack()
        {
            return HigherDamageAttack(HIGHER_DAMEGE_CHANCE, HIGHER_DAMEGE_PERCENT);
        }

        public override void DefendAgainst(int rawDamage)
        {
            HigherDefenceChance( rawDamage, HIGHER_DEFFENCE_CHANCE, HIGHER_DEFFENCE_PERCENT);
        }
    }
}
