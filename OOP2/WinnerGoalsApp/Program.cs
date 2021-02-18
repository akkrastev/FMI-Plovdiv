using System;

namespace WinnerGoalsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int res = Result.getWinnerTotalGoals("UEFA Champions League", 2011);

            Console.WriteLine(res);
        }
    }
}
