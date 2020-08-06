using System;
using System.Collections.Generic;

namespace DijkstraWithAdjList
{
    class AdjacencyList
    {
        LinkedList<Tuple<int, int>>[] adjList;

        /*In constructor create an empty linked list of size equal to number of vertices*/
        public AdjacencyList(int vertices)
        {
            adjList = new LinkedList<Tuple<int, int>>[vertices];

            /*create list for each vertex*/
            for(int i=0;i< vertices; i++)
            {
                adjList[i] = new LinkedList<Tuple<int, int>>();
            }
        }

        public void AddEdge(int start,int end,int weight)
        {
            /*Add edges in adj list from front: Insertion O(1)*/
            adjList[start].AddFirst(new Tuple<int,int>(end,weight));
        }

        public int GetNumberOfVertices()
        {
            /*return length of adjList*/
            return adjList.Length;
        }

        public LinkedList<Tuple<int, int>> getLinkedListwithSpeicficIndex(int index)
        {
            /*Returns the Linked List of outward edges from a vertex*/
            LinkedList<Tuple<int, int>> edgeList
                               = new LinkedList<Tuple<int, int>>(adjList[index]);

            return edgeList;
        }

        
        public void printAdjList()
        {
            /*Prints the Adjacency List*/
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
