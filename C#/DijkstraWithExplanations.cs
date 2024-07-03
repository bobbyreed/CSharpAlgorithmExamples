using System;

class DijkstraWithExplanations
{
    static void Main()
    {
        // Define the graph as an adjacency matrix
        Console.WriteLine("Initializing the graph as an adjancency matrix. Each row represents the distances to each node from 1 node. e.g. The first row shows the distances to the rest of the nodes from node A");
		Console.WriteLine("");
		int[,] graph = {
            { 0, 4, 0, 2, 0 },
            { 4, 0, 1, 0, 5 },
            { 0, 1, 0, 0, 0 },
            { 2, 0, 0, 0, 3 },
            { 0, 5, 0, 3, 0 }
        };

        int source = 0; // Start from node A (index 0)
		Console.WriteLine("Declaring int 'source' as 0. This defines our current location with index 0 representing node a");
		Console.WriteLine("");
        Console.WriteLine("Running dijkstra function passing through int[,] graph and the node " + source + " as source");
		Console.WriteLine("");
		Dijkstra(graph, source);
    }

    static void Dijkstra(int[,] graph, int source)
    {
		Console.WriteLine("Beginning Djikstra() by initializing distances, shortest path tree set, and parent nodes");
		Console.WriteLine("setting verticesCount to graph.GetLength(0)...");
        int verticesCount = graph.GetLength(0);
		Console.WriteLine("verticesCount = " + verticesCount);
		Console.WriteLine("int[] distances being created using verticesCount as the array length");
        int[] distances = new int[verticesCount];
		Console.WriteLine("distances has a length of " + distances.Length);
		Console.WriteLine("Creating bool[] shortestPathTreeSet...");
        bool[] shortestPathTreeSet = new bool[verticesCount];
		Console.WriteLine("shortestPathTreeSet has a length of " + shortestPathTreeSet.Length);
		Console.WriteLine("creating int[] parents...");
        int[] parents = new int[verticesCount];
		Console.WriteLine("parents has a length of " + parents.Length);
		Console.WriteLine("");

		//Initializes distances, shortest path tree set, and parent nodes
        for (int i = 0; i < verticesCount; i++)
        {
			Console.WriteLine("Adding placeholder values to arrays distances, shortestPathTreeSet, and parents at position " + i);
            distances[i] = int.MaxValue;
			Console.WriteLine("distances[" + i + "] is set to " + distances[i]);
            shortestPathTreeSet[i] = false;
			Console.WriteLine("shortestPathTreeSet[" + i + "] is set to " + shortestPathTreeSet[i]);
			parents[i] = -1;
			Console.WriteLine("parents[" + i + "] is set to " + parents[i]);
			Console.WriteLine("");
        }
		
        distances[source] = 0;
		Console.WriteLine("distances[source] = " + distances[source]);
		
		//This loop selects the minimum distance node not yet processed and updates distances of adjacent nodes.
        for (int count = 0; count < verticesCount - 1; count++)
        {
			Console.WriteLine("For each vertex, declare int u and set it is the minimum distance between distances[] and shortestPathTreeSet[]");
            int u = MinDistance(distances, shortestPathTreeSet);
			Console.WriteLine("int u = " + u);
			Console.WriteLine("hortestPathTreeSet[" + u + "] being set to true.");
            shortestPathTreeSet[u] = true;
			Console.WriteLine("");
			
			//nested forloop
				//REMINDERS OF FUNCTIONALITY
				//!shortestPathTreeSet[v]: Vertex v has not been processed yet. It would be true if it had been processed already.
				//Convert.ToBoolean(graph[u, v]): There is an edge between u and v.
				//distances[u] != int.MaxValue: The current distance to u is not infinity, which means u is reachable.
				//distances[u] + graph[u, v] < distances[v]: The new calculated distance to v through u is shorter than the current known distance to v.
            for (int v = 0; v < verticesCount; v++)
            {
                if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distances[u] != int.MaxValue && distances[u] + graph[u, v] < distances[v])
                {
                    distances[v] = distances[u] + graph[u, v];
					Console.WriteLine("The new calculated distance to " + v + " through " + u + " is shorter than the current known distance to " + v);
					Console.WriteLine("Updating parents[" + v + "] to " + u);
                    parents[v] = u;
					Console.WriteLine("parents[" + v + "] = " + parents[v]);
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
		Console.WriteLine("Initializing int min and int minIndex...");
		Console.WriteLine("int min holds the maximum value so any usable distance will be less than min.");
		Console.WriteLine("minIndex is initialized to -1 to indicate that no vertex has been found yet.");
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < distances.Length; v++)
        {
			Console.WriteLine("Checking conditions for v = " + v);
			Console.WriteLine("Checking that shortestPathTree[" + v + "] is false. This ensures the vertex [" + v + "] has not been processed yet.");
			Console.WriteLine("Checking that distances[" + v + "] <= min: This ensures the distance to vertex [" + v + "] is less than or equal to the current minimum distance.");
            if (!shortestPathTreeSet[v] && distances[v] <= min)
            {
                min = distances[v];
                minIndex = v;
				Console.WriteLine("min = " + min);
				Console.WriteLine("minIndex = " + minIndex);
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
