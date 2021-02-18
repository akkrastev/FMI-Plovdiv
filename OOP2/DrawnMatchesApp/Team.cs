using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnMatchesApp
{
    public class Team
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public int Total_Pages { get; set; }
        public List<Match> Data { get; set; }
    }
}
