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
            var dist = new int[vertices];
            var isIncluded = new bool[vertices];
            for (int i = 0; i < vertices; i++)
            {
                dist[i] = int.MaxValue;
                isIncluded[i] = false;
            }
            dist[source] = 0;

            for (int count = 0; count < vertices; count++)
            {
                int currentVertex = minDistanceVertices(dist, isIncluded, vertices);
                isIncluded[currentVertex] = true;
                LinkedList<Tuple<int, int>> list = adjList.getLinkedListwithSpeicficIndex(currentVertex);
                foreach (Tuple<int, int> edge in list)
                {
                    int dest = edge.Item1;
                    int value = edge.Item2;
                    if (isIncluded[dest] == false && dist[currentVertex] != int.MaxValue && dist[currentVertex] + value < dist[dest])
                    {
                        dist[dest] = dist[currentVertex] + value;
                    }
                }
            }

            for (int j = 0; j < vertices; j++)
            {
                Console.WriteLine($"distance of vertex {j} from source index {source} is: {dist[j]}");
            }
        }
    }
}
