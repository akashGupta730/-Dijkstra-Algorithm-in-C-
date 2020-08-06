using System;

namespace DijkstraWithAdjList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number of vertices:");
            int vertices = int.Parse(Console.ReadLine());
            AdjacencyList adjList = new AdjacencyList(vertices);
            FillEdges(adjList);
            adjList.printAdjList();
            Console.WriteLine("Enter Source vertex:");
            int source =  int.Parse(Console.ReadLine());
            Dijkstra dijkstra = new Dijkstra();
            dijkstra.CallDijkstra(adjList,source);
        }

        static void FillEdges(AdjacencyList adjList){
            while(true){
                Console.WriteLine("Enter an edge with weight or 'q' to quit");
                var input = Console.ReadLine();
                if(input=="q"){
                    break;
                }
                else{
                    int start = int.Parse(input);
                    int end = int.Parse(Console.ReadLine());
                    int weight = int.Parse(Console.ReadLine());
                    adjList.AddEdge(start,end,weight);
                    adjList.AddEdge(end,start,weight);
                }
            }
        }
       
    }
}
