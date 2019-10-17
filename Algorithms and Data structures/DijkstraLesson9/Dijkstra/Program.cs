using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Program
    {
        private static int[,] adjacencyMatrix;
        private static int[] solution;
        private static Boolean[] availableNodes;

        private static int nodesCount;

        static void Main(string[] args)
        {
            nodesCount = 9;

            adjacencyMatrix = new int[,] { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                           { 0, 0, 0,10, 0, 0, 0, 0, 0, 3},
                                           { 0, 0, 0, 7, 0, 0, 0, 0, 0, 0},
                                           { 0,10, 7, 0, 6, 0, 0, 0, 0, 0},
                                           { 0, 0, 0, 6, 0, 7, 0, 3, 0, 0},
                                           { 0, 0, 0, 0, 7, 0, 0, 4, 0,11},
                                           { 0, 0, 0, 0, 0, 0, 0, 5, 0, 0},
                                           { 0, 0, 0, 0, 3, 4, 5, 0, 0, 0},
                                           { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                                           { 0, 3, 0, 0, 0,11, 0, 0, 1, 0}
                                            };

            solution = new int[nodesCount + 1];
            availableNodes = new bool[nodesCount + 1];

            Dijkstra(1);

            for(int i=1;  i<= nodesCount; i++)
            {
                Console.Write(solution[i] + " ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }

        private static void Dijkstra(int node)
        {
            for(int i=1; i<= nodesCount; i++)
            {
                availableNodes[i] = true;

                if(adjacencyMatrix[node, i] <= 0)
                {
                    solution[i] = int.MaxValue;
                }
                else
                {
                    solution[i] = adjacencyMatrix[node, i];
                }
            }

            availableNodes[node] = false;
            solution[node] = 0;

            while(true)
            {
                int j = int.MaxValue;
                int distance = int.MaxValue;

                // Find an available node
                for(int i=1; i<=nodesCount; i++)
                {
                    if(availableNodes[i] && solution[i] < distance)
                    {
                        distance = solution[i];

                        j = i;
                    }
                }

                // If no available nodes, we are done
                if(j == int.MaxValue)
                {
                    break;
                }

                // There is an available node, so continue...
                availableNodes[j] = false;

                for(int i=1; i<=nodesCount; i++)
                {
                    if(availableNodes[i] && adjacencyMatrix[j, i] > 0)
                    {
                        if(solution[i] > (solution[j] + adjacencyMatrix[j, i]))
                        {
                            solution[i] = solution[j] + adjacencyMatrix[j, i];
                        }
                    }
                }

            }
        }
    }
}
