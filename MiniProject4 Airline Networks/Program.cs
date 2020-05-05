using System;
using System.Net.Mime;
using MiniProject4_Airline_Networks.Utils;

namespace MiniProject4_Airline_Networks
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = TextParser.ReadText("routes.txt");

            var bla = TextParser.ParseRoutes(test);

            foreach (var route in bla)
            {
                Console.WriteLine(route);
            }

            // split string into list of Route objects
            //
            // Make Graph based on routes
            //
            //
            // Compare timings between BreadthFirstSearch and DepthFirstSearch 
            //
            //
            // Use Dijkstra's algorithm to find shortestpath, both on Route's distance and time attributes
        }
    }
}