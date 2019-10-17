using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGame
{
    public class Knight : Hero
    {
        private const int BLOCK_ATTACK_CHANCE = 20;
        private const int HIGHER_DAMEGE_CHANCE = 10;
        private const int HIGHER_DAMEGE_PERCENT = 200;

        public Knight(string name, int attack, int defence, int health) : base(name, attack, defence, health)
        {

        }

        public override int Attack()
        {
            return HigherDamageAttack(HIGHER_DAMEGE_CHANCE, HIGHER_DAMEGE_PERCENT);
        }
        public override void DefendAgainst(int rawDamage)
        {
            DefenceBlockAttack(rawDamage, BLOCK_ATTACK_CHANCE);
        }
    }
}
