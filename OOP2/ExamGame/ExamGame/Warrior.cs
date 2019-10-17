using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGame
{
   public  class Warrior : Hero
    {
        public Warrior(string name, int attack, int defence, int health) : base(name, attack, defence, health)
        {

        }
        public override int Attack()
        {
            return DefaultAttack();
        }
        public override void DefendAgainst(int rawDamage)
        {
            DefaultDefence(rawDamage);
        }
    }
}
