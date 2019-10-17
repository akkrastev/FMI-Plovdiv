using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGame
{
     public class DefenceEndArgs : EventArgs
    {
        public Hero Defender { get; set; }
        public int attackDmg { get; set; }
        public int healthPoints { get; set; }
    }
}
