using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGame
{
    public class Monk : Hero
    {
        private const int BLOCK_ATTACK_CHANCE = 30;
        public Monk(string name, int attack, int defence, int health) : base(name, attack, defence, health)
        {

        }
        public override int Attack()
        {
            return DefaultAttack();
        }
        public override void DefendAgainst(int rawDamage)
        {
            DefenceBlockAttack(rawDamage, BLOCK_ATTACK_CHANCE);
        }
    }
}
