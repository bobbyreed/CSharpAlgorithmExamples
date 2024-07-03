using System;

class DijkstraAlgorithm
{
    static void Main()
    {
        // Define the graph as an adjacency matrix
		int[,] graph = {
            { 0, 4, 0, 2, 0 },
            { 4, 0, 1, 0, 5 },
            { 0, 1, 0, 0, 0 },
            { 2, 0, 0, 0, 3 },
            { 0, 5, 0, 3, 0 }
        };

        int source = 0; // Start from node A (index 0)
		Dijkstra(graph, source);
    }

    static void Dijkstra(int[,] graph, int source)
    {
        int verticesCount = graph.GetLength(0);
        int[] distances = new int[verticesCount];
        bool[] shortestPathTreeSet = new bool[verticesCount];
        int[] parents = new int[verticesCount];

        for (int i = 0; i < verticesCount; i++)
        {
            distances[i] = int.MaxValue;
            shortestPathTreeSet[i] = false;
			parents[i] = -1;
        }
		
        distances[source] = 0;

        for (int count = 0; count < verticesCount - 1; count++)
        {
            int u = MinDistance(distances, shortestPathTreeSet);
            shortestPathTreeSet[u] = true;
			
            for (int v = 0; v < verticesCount; v++)
            {
                if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distances[u] != int.MaxValue && distances[u] + graph[u, v] < distances[v])
                {
                    distances[v] = distances[u] + graph[u, v];
                    parents[v] = u;
                }
            }

            Console.WriteLine("");
			Console.WriteLine("Step " + (count + 1) + ":");
            PrintStep(distances, parents, u, source);
            Console.WriteLine();
        }

        PrintSolution(distances, parents, source);
    }

    static int MinDistance(int[] distances, bool[] shortestPathTreeSet)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < distances.Length; v++)
        {
            if (!shortestPathTreeSet[v] && distances[v] <= min)
            {
                min = distances[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    static void PrintStep(int[] distances, int[] parents, int currentNode, int source)
    {
        Console.WriteLine("Current node: " + Convert.ToChar(currentNode + 'A'));
        Console.WriteLine("Distances from source:");
        for (int i = 0; i < distances.Length; i++)
        {
            if (distances[i] == int.MaxValue)
            {
                Console.WriteLine(Convert.ToChar(i + 'A') + ": ∞");
            }
            else
            {
                Console.WriteLine(Convert.ToChar(i + 'A') + ": " + distances[i]);
            }
        }

        Console.WriteLine("");
		Console.WriteLine("Parent nodes:");
        for (int i = 0; i < parents.Length; i++)
        {
            if (i != source)
            {
                if (parents[i] != -1)
                {
                    Console.WriteLine(Convert.ToChar(i + 'A') + ": " + Convert.ToChar(parents[i] + 'A'));
                }
                else
                {
                    Console.WriteLine(Convert.ToChar(i + 'A') + ": None");
                }
            }
        }
    }

    static void PrintSolution(int[] distances, int[] parents, int source)
    {
        Console.WriteLine("Vertex\t Distance from Source\tPath");

        for (int i = 0; i < distances.Length; i++)
        {
            if (i != source)
            {
                Console.Write("\n" + Convert.ToChar(source + 'A') + " -> ");
                Console.Write(Convert.ToChar(i + 'A') + " \t\t ");
                Console.Write(distances[i] + "\t\t");
                PrintPath(i, parents);
            }
        }
    }

    static void PrintPath(int currentVertex, int[] parents)
    {
        if (currentVertex == -1)
        {
            return;
        }
        PrintPath(parents[currentVertex], parents);
        Console.Write(Convert.ToChar(currentVertex + 'A') + " ");
    }
}
