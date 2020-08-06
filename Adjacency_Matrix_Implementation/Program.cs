using System;
using System.Collections.Generic;

namespace Dijkstra
{
    class Program
    {
        public int minDistanceVertices(int[] dist, bool[] isIncluded,int vertices){
            var minDist=int.MaxValue;
            var minIndex=-1;
            for(int index=0;index<vertices;index++){
                if(isIncluded[index]==false && dist[index]<minDist){
                    minDist=dist[index];
                    minIndex=index;
                }
            }
            return minIndex;
        }
        public void dijkstra(int [,] graph,int source){
            var vertices = graph.GetLength(0);
            var dist = new int[vertices];
            var isIncluded = new bool[vertices];
            for(int i=0;i<vertices;i++){
                dist[i]=int.MaxValue;
                isIncluded[i]=false;
            }
            dist[source]=0;
            for(int count =0; count<vertices;count++){
                int currentVertex = minDistanceVertices(dist,isIncluded,vertices);
                isIncluded[currentVertex] = true;
                for(int i=0;i<vertices;i++){
                    if(graph[currentVertex,i]!=0 && isIncluded[i]==false && dist[currentVertex]!=int.MaxValue && dist[currentVertex]+graph[currentVertex,i]<dist[i]){
                        dist[i]=dist[currentVertex]+graph[currentVertex,i];
                    }
                }
            }
            for(int j =0 ;j< vertices;j++){
                Console.WriteLine($"distance of vertex {j} from source index {source} is: {dist[j]}");
            }
        }

        static void Main(string[] args)
        {
            var graph = new [,] {{0,5,12},{5,0,3},{12,3,0}};
            Program p = new Program();
            p.dijkstra(graph,0);
        }

    }
}
