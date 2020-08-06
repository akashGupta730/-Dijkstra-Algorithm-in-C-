using System;
using System.Collections.Generic;

namespace Dijkstra
{
    class Program
    {
        public int minDistanceVertices(int[] dist, bool[] isIncluded,int vertices){
            var minDist=int.MaxValue;
            var minIndex=-1;

            /*Find vertex with minimum distance which is not included in shortest path*/
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

            /*Dist will contain shortest distance for each vertex from source*/
            var dist = new int[vertices];

            /*isIncluded[i ] will true if vertex i is included in shortest path*/
            var isIncluded = new bool[vertices];

            /*Initialise all distnace with infinity and isIncluded false*/
            for(int i=0;i<vertices;i++){
                dist[i]=int.MaxValue;
                isIncluded[i]=false;
            }

            /*Distance of source vertex from itself is 0*/
            dist[source]=0;

            /*Find Shortest path for every vertex*/
            for(int count =0; count<vertices;count++){
                /*Pick vertex with minimum distance from source and not included in shortest path*/
                int currentVertex = minDistanceVertices(dist,isIncluded,vertices);
                isIncluded[currentVertex] = true;

                for(int i=0;i<vertices;i++){
                     /*update distance if there is path from source to dest and its not included in shortest path and path distance from source to this vertex is less than current distance*/
                    if(graph[currentVertex,i]!=0 && isIncluded[i]==false && dist[currentVertex]!=int.MaxValue && dist[currentVertex]+graph[currentVertex,i]<dist[i]){
                        dist[i]=dist[currentVertex]+graph[currentVertex,i];
                    }
                }
            }

            /*Print shortest path*/
            for(int j =0 ;j< vertices;j++){
                Console.WriteLine($"distance of vertex {j} from source index {source} is: {dist[j]}");
            }
        }

        static void Main(string[] args)
        {
             /*Main function for Algorithm*/
             /*Create Adj Matrix*/
            var graph = new [,] {{0,5,12},{5,0,3},{12,3,0}};

            /*Call Dijkstra algorithm*/
            Program p = new Program();
            p.dijkstra(graph,0);
        }

    }
}
