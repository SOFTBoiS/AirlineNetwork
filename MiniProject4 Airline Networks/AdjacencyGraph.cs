using System;
using System.Collections.Generic;
using System.Linq;
using MiniProject4_Airline_Networks.Utils;

namespace MiniProject4_Airline_Networks
{
    public class AdjacencyGraph : IGraph
    {
        public int V { get; }
        public int E { get; private set; }
        private readonly EdgeNode[] _vertices;
        private readonly Dictionary<string, int> _airports;

        public AdjacencyGraph(int v, Dictionary<string, int> airports)
        {
            V = v;
            E = 0;
            _vertices = new EdgeNode[v];
            _airports = airports;
        }

        private class EdgeNode
        {
            internal Route route;
            internal int v;
            internal EdgeNode next;

            internal EdgeNode(int v, EdgeNode next, Route route)
            {
                this.v = v;
                this.next = next;
                this.route = route;
            }

            public override string ToString()
            {
                return $"Destination code: {route.DESTINATION_CODE}";
            }
        }

        public void AddEdge(int v, int w)
        {
            throw new NotImplementedException();
        }

        public void AddEdge(Route route)
        {
            var node = new EdgeNode(_airports[route.SOURCE_CODE], _vertices[_airports[route.DESTINATION_CODE]], route);
            _vertices[_airports[route.DESTINATION_CODE]] = node;
            E++;
        }

        public IEnumerable<int> Adjacents(int v)
        {
            IList<int> adjacents = new List<int>();
            var node = _vertices[v];
            while (node != null)
            {
                adjacents.Add(node.v);
                node = node.next;
            }

            return adjacents;
        }

        public override string ToString()
        {
            var text = "";
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (var item in _airports)
            {
                dict.Add(item.Value, item.Key);
            }

            for (var v = 0; v < V; v++)
            {
                var adjacents = "";
                var vertex = _vertices[v];
                EdgeNode vertexAdjacent;
                try
                {
                    if (vertex != null)
                    {
                        foreach (var number in Adjacents(v))
                        {
                            vertexAdjacent = _vertices[number];
                            if (vertexAdjacent != null) adjacents += vertexAdjacent.route.DESTINATION_CODE + ", ";
                        }

                        text += "" + vertex.route.SOURCE_CODE + ": " + adjacents + "\n";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return text;
        }

        // static void Main(String[] args)
        // {
        //     IGraph g = new AdjacencyGraph(6);
        //     g.AddEdge(0, 1);
        //     g.AddEdge(0, 2);
        //     g.AddEdge(2, 0);
        //     g.AddEdge(2, 3);
        //     g.AddEdge(2, 4);
        //     g.AddEdge(2, 4);
        //     g.AddEdge(2, 4);
        //     g.AddEdge(3, 4);
        //     g.AddEdge(3, 5);
        //     g.AddEdge(5, 0);
        //     g.AddEdge(5, 3);
        //     Console.WriteLine(g);
        //     /*
        //       0: [2, 1]
        //       1: []
        //       2: [4, 3, 0]
        //       3: [5, 4]
        //       4: []
        //       5: [3, 0]
        //     */
        // }
    }
}