using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prim_s_MST
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter number of vertices: ");
            int vert = int.Parse(Console.ReadLine());
            int[,] graph = new int[vert, vert];

            for (int i = 0; i < vert; i++)
            {
                for (int j = 0; j < vert; j++)
                {
                    Console.WriteLine("Enter weight of edge: " + i + ", " + j);
                    graph[i, j] = int.Parse(Console.ReadLine());
                }
            }

            MST.primMST(graph);
            Console.ReadKey();
        }
    }
    class MST
    {
        static int V = 5;

        static int minKey(int[] key, bool[] mstSet)
        {

            // Initialize min value
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    min_index = v;
                }

            return min_index;
        }

        static void printMST(int[] parent, int[,] graph)
        {
            Console.WriteLine("Edge \tWeight");
            for (int i = 1; i < V; i++)
                Console.WriteLine(parent[i] + " - " + i + "\t"
                                + graph[i, parent[i]]);
        }

        public static void primMST(int[,] graph)
        {

            int[] parent = new int[V];

            int[] key = new int[V];

            bool[] mstSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < V - 1; count++)
            {

                int u = minKey(key, mstSet);


                mstSet[u] = true;


                for (int v = 0; v < V; v++)


                    if (graph[u, v] != 0 && mstSet[v] == false
                        && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
            }

            printMST(parent, graph);
        }
    }
}
