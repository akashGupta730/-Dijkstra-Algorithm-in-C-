using System;
using System.Collections.Generic;

namespace DijkstraWithAdjList
{
    class AdjacencyList
    {
        LinkedList<Tuple<int, int>>[] adjList;

        //In constructor create an empty linked list of size equal to number of vertices
        public AdjacencyList(int vertices)
        {
            adjList = new LinkedList<Tuple<int, int>>[vertices];
            for(int i=0;i< vertices; i++)
            {
                adjList[i] = new LinkedList<Tuple<int, int>>();
            }
        }

        public void AddEdge(int start,int end,int weight)
        {
            adjList[start].AddFirst(new Tuple<int,int>(end,weight));
        }

        public int GetNumberOfVertices()
        {
            return adjList.Length;
        }

        public LinkedList<Tuple<int, int>> getLinkedListwithSpeicficIndex(int index)
        {
            LinkedList<Tuple<int, int>> edgeList
                               = new LinkedList<Tuple<int, int>>(adjList[index]);

            return edgeList;
        }

        // Prints the Adjacency List
        public void printAdjList()
        {
            int i = 0;

            foreach (LinkedList<Tuple<int, int>> list in adjList)
            {
                Console.Write("adjacencyList[" + i + "] -> ");

                foreach (Tuple<int, int> edge in list)
                {
                    Console.Write("( dest: "+ edge.Item1 + " Weight: " + edge.Item2 + "  ) ");
                }

                ++i;
                Console.WriteLine();
            }
        }
    }
}
