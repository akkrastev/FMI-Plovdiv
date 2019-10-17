using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGame
{
     public class AttackEndArgs : EventArgs
    {
        public Hero Attacker { get; set; }
    }
}
