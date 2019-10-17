using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGame
{
   public class DeadHeroArgs : EventArgs
    {
        public Hero DeadHero { get; set; }
    }
}
