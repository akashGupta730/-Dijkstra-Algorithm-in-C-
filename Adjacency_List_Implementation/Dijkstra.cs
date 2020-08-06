using System;
using System.Collections.Generic;
namespace DijkstraWithAdjList
{
    class Dijkstra
    {
        public int minDistanceVertices(int[] dist, bool[] isIncluded, int vertices)
        {
            var minDist = int.MaxValue;
            var minIndex = -1;

            /*Find vertex with minimum distance which is not included in shortest path*/
            /*Can be optimized using min Heap*/
            for (int index = 0; index < vertices; index++)
            {
                if (isIncluded[index] == false && dist[index] < minDist)
                {
                    minDist = dist[index];
                    minIndex = index;
                }
            }
            return minIndex;
        }

        public void CallDijkstra(AdjacencyList adjList, int source)
        {
            int vertices = adjList.GetNumberOfVertices();

            /*Dist will contain shortest distance for each vertex from source*/
            var dist = new int[vertices];

            /*isIncluded[i ] will true if vertex i is included in shortest path*/
            var isIncluded = new bool[vertices];

            /*Initialise all distnace with infinity and isIncluded false*/
            for (int i = 0; i < vertices; i++)
            {
                dist[i] = int.MaxValue;
                isIncluded[i] = false;
            }

            /*Distance of source vertex from itself is 0*/
            dist[source] = 0;

            /*Find Shortest path for every vertex*/
            for (int count = 0; count < vertices; count++)
            {
                /*Pick vertex with minimum distance from source and not included in shortest path*/
                int currentVertex = minDistanceVertices(dist, isIncluded, vertices);
                isIncluded[currentVertex] = true;

                /*Get Linked List of outward edges from currentVertex*/
                LinkedList<Tuple<int, int>> list = adjList.getLinkedListwithSpeicficIndex(currentVertex);
                foreach (Tuple<int, int> edge in list)
                {
                    int dest = edge.Item1;
                    int value = edge.Item2;
                    /*update distance if its not included in shortest path and path distance from source to this vertex is less than current distance*/
                    if (isIncluded[dest] == false && dist[currentVertex] != int.MaxValue && dist[currentVertex] + value < dist[dest])
                    {
                        dist[dest] = dist[currentVertex] + value;
                    }
                }
            }

            /*Print shortest path*/
            for (int j = 0; j < vertices; j++)
            {
                Console.WriteLine($"distance of vertex {j} from source index {source} is: {dist[j]}");
            }
        }
    }
}
