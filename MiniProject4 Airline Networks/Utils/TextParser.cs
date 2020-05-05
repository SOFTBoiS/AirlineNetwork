using System;
using System.Collections.Generic;

namespace MiniProject4_Airline_Networks.Utils
{
    public class TextParser
    {
        public static string ReadText(string fileName, string path = @"..\..\..\Data\")
        {
            try
            {
                return System.IO.File.ReadAllText(path + fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static List<Route> ParseRoutes(string text)
        {
            var rows = text.Split("\n");

            var routes = new List<Route>();

            for (int i = 1; i < rows.Length-1; i++)
            {
                var row = rows[i].Split(";");
                routes.Add(new Route(
                    row[0], 
                    row[1], 
                    row[2], 
                    Convert.ToDouble(row[3]),
                    Convert.ToDouble(row[4])
                ));
            }
            //if we want to use arrays instead of list (right now index out of bounds issues lol)
            // var routes = new Route[rows.Length-1];
            //     
            // for (int i = 0; i < rows.Length-1; i++)
            // {
            //     var row = rows[i+1].Split(";");
            //     var route = new Route(
            //         row[0], 
            //         row[1], 
            //         row[2], 
            //         Convert.ToDouble(row[3]),
            //         Convert.ToDouble(row[4])
            //         );
            //     routes[i] = route;
            // }
            return routes;
        }
    }

    public class Route
    {
        public readonly string AIRLINE_CODE;
        public readonly string SOURCE_CODE;
        public readonly string DESTINATION_CODE;
        public readonly double DISTANCE;
        public readonly double TIME;

        public Route(string airlineCode, string sourceCode, string destinationCode, double distance, double time)
        {
            AIRLINE_CODE = airlineCode;
            SOURCE_CODE = sourceCode;
            DESTINATION_CODE = destinationCode;
            DISTANCE = distance;
            TIME = time;
        }

        public override string ToString()
        {
            return $"Airline code: {AIRLINE_CODE}, " +
                   $"Source code: {SOURCE_CODE}, " +
                   $"Destination code: {DESTINATION_CODE}, " +
                   $"Distance: {DISTANCE.ToString()}, " +
                   $"Time: {TIME.ToString()}";

        }
    }
}