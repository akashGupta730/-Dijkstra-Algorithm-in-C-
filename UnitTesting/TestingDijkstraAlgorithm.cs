using System;
using Xunit;

namespace DijkstraWithAdjList.Tests
{
    public class TestingDijkstraAlgorithm
    {
        [Fact]
        public void TestShortestDistance()
        {
            /*arrange*/
            int NoOfVertices = 3;
            AdjacencyList adjList = new AdjacencyList(NoOfVertices);
            adjList.AddEdge(0,1,5);
            adjList.AddEdge(0,2,12);
            adjList.AddEdge(1,2,3);

            int source = 0;
            Dijkstra dijkstra = new Dijkstra(NoOfVertices,source);
            dijkstra.CallDijkstra(adjList,source);
            
            // act
            int destination=2;
            int shortestDistance = dijkstra.returnShortestPathValue(destination);

            //assert
            Assert.Equal(8,shortestDistance);
        }
    }
}
