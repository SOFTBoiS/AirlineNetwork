using System;
using System.Collections.Generic;
using MiniProject4_Airline_Networks.Basics;

namespace MiniProject4_Airline_Networks
{
    public class DijkstraShortestPath
    {
        private readonly WeightedGraph graph;
        private readonly string source;
        private Dictionary<string, string> edgeTo;
        private Dictionary<string, double> distTo;
        private PriorityQueue<Path> pqMin = new PriorityQueue<Path>(1000000000);

        public DijkstraShortestPath(WeightedGraph graph, string source)
        {
            this.graph = graph;
            this.source = source;
            edgeTo = new Dictionary<string, string>();
            distTo = new Dictionary<string, double>();

            var test = graph.Vertices;
            foreach (var airportCode in test.Keys)
            {
                edgeTo.Add(airportCode, "");
                distTo.Add(airportCode, Double.PositiveInfinity);
            }

            edgeTo[source] = source;
            distTo[source] = 0;
            pqMin.Enqueue(new Path(source, 0.0));
            Build();
        }

        public class Path : IComparable<Path> {
            public string v;
            double weight;

            public Path(string v, double weight) {
                this.v = v;
                this.weight = weight;
            }

            public override string ToString()
            {
                return "" + v + ": " + weight;
            }

            public int CompareTo(Path other)
            {
                if (this.weight < other.weight) return -1;
                if (this.weight > other.weight) return 1;
                return 0;
            }
        }

        private void Build()
        {
            while (!pqMin.IsEmpty())
            {
                Path path = pqMin.Dequeue();
                Relax(path);
            }
        }

        private void Relax(Path path)
        {
            var adj = graph.Adjacents(path.v);
            foreach (var edge in adj) 
            {
                double newDistance = distTo[edge._from] + edge.Weight;
                if (distTo[edge.To] > newDistance)
                {
                    // update distTo and edgeTo...
                    distTo[edge.To] = newDistance;
                    edgeTo[edge.To] = edge._from;
                    // update priority queue
                    pqMin.Enqueue(new Path(edge.To, newDistance));
                }
            }
        }

        public String showPathTo(string w)
        {
            String path = "" + w;
            while (edgeTo[w] != w && edgeTo[w] != "")
            {
                w = edgeTo[w];
                path = "" + w + " -> " + path;
            }

            return path;
        }
        
        public void Print()
        {
            foreach (var airport in graph.Vertices)
            {
                Console.WriteLine($"{airport.Key}: {showPathTo(airport.Key)}");
            }
            
            // for (int v = 0; v < graph.getV(); v++)
            //     out. println("" + v + ": " + showPathTo(v));
        }
        
        // public static void main(String[] args)
        // {
        //     WeightedGraph g = new WeightedGraph(6);
        //     g.AddEdge(0, 2, 3.0);
        //     g.AddEdge(0, 1, 2.0);
        //     g.AddEdge(0, 5, 1.0);
        //     g.AddEdge(2, 4, 4.0);
        //     g.AddEdge(2, 3, 3.0);
        //     g.AddEdge(3, 4, 5.0);
        //     g.AddEdge(5, 3, 2.0);
        //
        //     DijsktraShortestPath dsp = new DijsktraShortestPath(g, 0);
        //     dsp.print(System.out);
        // }
    }
}