using System;

namespace DijkstraWithAdjList
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Main function for Algorithm*/

            Console.WriteLine("Enter Number of vertices:");
            int vertices = int.Parse(Console.ReadLine());

            /*Create AdjacencyList of size equal to number of vertices*/
            AdjacencyList adjList = new AdjacencyList(vertices);

            /*Function is called for filling the AdjacencyList*/
            FillEdges(adjList);
            adjList.printAdjList();

            Console.WriteLine("Enter Source vertex:");
            int source =  int.Parse(Console.ReadLine());

            /*Call Dijkstra algorithm*/
            Dijkstra dijkstra = new Dijkstra(vertices,source);
            dijkstra.CallDijkstra(adjList,source);
        }
        
        static void FillEdges(AdjacencyList adjList){
            /*Function is called for filling the AdjacencyList*/
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

                    /*Add edges. Since this is undirected graph so we need to add source->destination as well as destination->source*/
                    adjList.AddEdge(start,end,weight);
                    //adjList.AddEdge(end,start,weight);
                }
            }
        }
       
    }
}
