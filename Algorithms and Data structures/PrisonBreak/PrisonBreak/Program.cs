using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonBreak
{
    class Program
    {
        public static readonly int BOARD_SIZE = 15;
        public static int[,] board;
        public static int[,] solution = new int[BOARD_SIZE,BOARD_SIZE];

        public static void printMaze()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }
         public static void printSolution()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    Console.Write(solution[i,j] + "\t");
                }
                Console.Write("\n\n");
            }
        }

        //funtion to solve the maze

       private static bool solveMaze(int r, int c)
        {
            if((r == BOARD_SIZE - 1) && (c == BOARD_SIZE - 1))
            {
                solution[r,c] = 1;
                return true;
            }
             
            if(r >= 0 && c >= 0 && r < BOARD_SIZE && c < BOARD_SIZE && solution[r,c] == 0 && board[r,c] == 0)
            {
                solution[r,c] = 1;
                //going down
                if (solveMaze(r + 1, c))
                    return true;
                //going right
                if (solveMaze(r, c + 1))
                    return true;
                //going up
                if (solveMaze(r - 1, c))
                    return true;
                //going left
                if (solveMaze(r, c - 1))
                    return true;
                //backtracking
                solution[r,c] = 0;
                return false;
            }
            return false;

        }

        static void Main(string[] args)
        {
            // Get random board
            board = PrisonBreakTools.getNewMaze(BOARD_SIZE);
            printMaze();

            // Get random staring point
            Random rand = new Random();
            int startX, startY;
            do
            {
                startX = rand.Next(0, BOARD_SIZE);
                startY = rand.Next(0, BOARD_SIZE);
            }
            while (board[startX, startY] != TileTypes.EMPTY || startX == 0 || startY == 0 || startX == BOARD_SIZE-1 || startY == BOARD_SIZE-1);

            Console.WriteLine("Start: {0} {1}", startX, startY);
            
            // Your output goes here



            Console.ReadKey();
        }
    }
}
