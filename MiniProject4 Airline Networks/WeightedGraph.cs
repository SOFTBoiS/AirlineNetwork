using System.Collections;
using System.Collections.Generic;
using MiniProject4_Airline_Networks.Utils;

namespace MiniProject4_Airline_Networks
{
    public class WeightedGraph
    {
        public Dictionary<string, IList<Edge>> Vertices { get; }
        public static bool WeightIsDistance;

        public WeightedGraph(List<string> airports, bool isDistance)
        {
            Vertices = new Dictionary<string, IList<Edge>>();

            foreach (var airportName in airports)
            {
                Vertices.Add(airportName, new List<Edge>());
            }

            WeightIsDistance = isDistance;

        }

        public void AddEdge(Route route)
        {
            Edge edge = new Edge(route);
            
            Vertices[route.SOURCE_CODE].Add(edge);
        }

        public int GetV()
        {
            return Vertices.Count;
        }

        public IEnumerable<Edge> Adjacents(string airportCode)
        {
            return Vertices[airportCode];
        }

        public class Edge
        {
            public string _from;
            public string To { get; }
            private double _distance;
            private double _time;
            public double Weight => WeightIsDistance ? _distance : _time + 1;

            public Edge(Route route)
            {
                _from = route.SOURCE_CODE;
                To = route.DESTINATION_CODE;
                _distance = route.DISTANCE;
                _time = route.TIME;
            }
        }

        public override string ToString()
        {
            string text = "";
            string adjacents;

            foreach (var airport in Vertices)
            {
                adjacents = "";
                foreach (var destination in Adjacents(airport.Key))
                {
                    adjacents += $"{destination.To}, ";
                }
                text += $"{airport.Key}: {adjacents} \n";
            }

            return text;
        }
    }
}