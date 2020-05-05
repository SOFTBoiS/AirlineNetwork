using System;
using System.Collections.Generic;

namespace MiniProject4_Airline_Networks
{
    public class AdjacencyGraph : IGraph
    {
        public int V { get; }
        public int E { get; private set; }
        private readonly EdgeNode[] _vertices;

        public AdjacencyGraph(int v) {
            V = v;
            E = 0;
            _vertices = new EdgeNode[v];
        }

        private class EdgeNode {
            internal int v;
            internal EdgeNode next;

            internal EdgeNode(int v, EdgeNode next) {
                this.v = v;
                this.next = next;
            }
        }

        public void AddEdge(int v, int w) {
            var node = new EdgeNode(w, _vertices[v]);
            _vertices[v] = node;
            E++;
        }

        public IEnumerable<int> Adjacents(int v) {
            IList<int> adjacents = new List<int>();
            var node = _vertices[v];
            while (node != null) {
                adjacents.Add(node.v);
                node = node.next;
            }
            return adjacents;
        }

        public override string ToString() {
            var text = "";
            for (var v = 0; v < V; v++) {
                var adjacents = "";
                foreach (var number in Adjacents(v))
                {
                    adjacents += number + ", ";
                }
                text += ""+v+": "+adjacents+"\n";
            }
            return text;
        }

        // static void Main(String[] args) {
        //     IGraph g = new AdjacencyGraph(6);
        //     g.AddEdge(0, 1);
        //     g.AddEdge(0, 2);
        //     g.AddEdge(2, 0);
        //     g.AddEdge(2, 3);
        //     g.AddEdge(2, 4);
        //     g.AddEdge(3, 4);
        //     g.AddEdge(3, 5);
        //     g.AddEdge(5, 0);
        //     g.AddEdge(5, 3);
        //     Console.WriteLine(g);
            /*
              0: [2, 1]
              1: []
              2: [4, 3, 0]
              3: [5, 4]
              4: []
              5: [3, 0]
            */
        // }

    }
}