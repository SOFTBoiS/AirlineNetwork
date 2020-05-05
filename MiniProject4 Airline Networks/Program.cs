using System;
using System.Net.Mime;
using MiniProject4_Airline_Networks.Utils;

namespace MiniProject4_Airline_Networks
{
    class Program
    {
        static void Main(string[] args)
        {
            // split string into list of Route objects
            var routesText = TextParser.ReadText("routes.txt");
            var routes = TextParser.ParseRoutes(routesText);


            // Make Graph based on routes
            var airportText = TextParser.ReadText("airports.txt");
            var airports = TextParser.ParseAirports(airportText);
            IGraph graph = new AdjacencyGraph(routes.Count, airports);
            
            foreach (var route in routes)
            {
                graph.AddEdge(route);
            }
            
            Console.WriteLine(graph);
            // Compare timings between BreadthFirstSearch and DepthFirstSearch 
            //
            //
            // Use Dijkstra's algorithm to find shortestpath, both on Route's distance and time attributes
        }
    }
}