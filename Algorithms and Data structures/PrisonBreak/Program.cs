using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonBreak
{
    class Program
    {
        public class Door
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        public static List<Door> doors = new List<Door>();
        public static readonly int BOARD_SIZE = 1500;
        public static int[,] board;
        public static bool hasPath = false;

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

        public static bool CanPass(int x, int y)
        {
            if (board[x, y] != TileTypes.WALL)
            {
                return true;
            }

            return false;
        }

        public static bool IsExit(int x, int y)
        {
            if (board[x, y] != TileTypes.WALL)
            {
                if (x == 0 || x == BOARD_SIZE - 1 || y == 0 || y == BOARD_SIZE - 1)
                {
                    return true;
                }
            }

            return false;
        }

        public static void CloseDoors(int x, int y)
        {
            //List<Door> blockingDoors = new List<Door>();
            bool check = false;
            foreach (var d in doors.ToList())
            {
                board[d.X, d.Y] = TileTypes.WALL;
                hasPath = false;
                Solution(x, y);
                if (!hasPath)
                {
                    check = true;
                    Console.WriteLine("Closing Door: {0},{1}", d.X, d.Y);
                }

                board[d.X, d.Y] = TileTypes.EMPTY;
            }

            if (!check)
            {
                Console.WriteLine("No blocking doors");
            }
        }

        public static void Solution(int x, int y)
        {
            if (hasPath)
            {
                return;
            }

            if (!CanPass(x, y))
            {
                return;
            }

            if (TileTypes.DOOR == board[x, y])
            {
                doors.Add(new Door { X = x, Y = y });
            }


            if (IsExit(x, y))
            {
                hasPath = true;
                Console.WriteLine("Path found !!!!");
                return;
            }
            var curBlock = board[x, y];
            //TOP
            if (x > 0)
            {
                board[x, y] = TileTypes.WALL;
                Solution(x - 1, y);
                board[x, y] = curBlock;
            }

            //Down
            if (x < BOARD_SIZE - 1)
            {
                board[x, y] = TileTypes.WALL;
                Solution(x + 1, y);
                board[x, y] = curBlock;
            }

            //Left
            if (y > 0)
            {
                board[x, y] = TileTypes.WALL;
                Solution(x, y - 1);
                board[x, y] = curBlock;
            }

            //Right
            if (y < BOARD_SIZE - 1)
            {
                board[x, y] = TileTypes.WALL;
                Solution(x, y + 1);
                board[x, y] = curBlock;
            }

        }

        static void Main(string[] args)
        {
            // Get random board
            board = /*new int[,]
            {
                    {1,0,0,1,0},
                    {1,2,2,1,0},
                    {0,0,1,0,1},
                    {1,0,1,2,1},
                    {1,1,0,0,1}
           };*/
            PrisonBreakTools.getNewMaze(BOARD_SIZE);
            //printMaze();

            // Get random staring point
            Random rand = new Random();
            int startX, startY;
            do
            {
                startX = rand.Next(0, BOARD_SIZE);
                startY = rand.Next(0, BOARD_SIZE);
            }
            while (board[startX, startY] != TileTypes.EMPTY || startX == 0 || startY == 0 || startX == BOARD_SIZE - 1 || startY == BOARD_SIZE - 1);

           // startX = 3;
            //startY = 1;

            Console.WriteLine("Start: {0} {1}", startX, startY);

            // Your output goes here

            Solution(startX, startY);
            if (hasPath)
            {
                Console.WriteLine("Has path");
                if (doors.Count > 0)
                {
                    CloseDoors(startX, startY);
                }
            }
            else
            {
                Console.WriteLine("No path");
            }
            Console.ReadKey();
        }
    }
}
