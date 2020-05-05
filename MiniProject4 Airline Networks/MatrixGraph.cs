using System;
using System.Collections.Generic;

namespace MiniProject4_Airline_Networks
{
    public class MatrixGraph : IGraph
    {
        public int V { get; }
        public int E { get; private set; }
        private bool[,] _edges;

        public MatrixGraph(int v) {
            V = v;
            E = 0;
            _edges = new bool[v,v];
        }

        public void AddEdge(int v, int w) {
            _edges[v,w] = true;
            E++;
        }
        
        public IEnumerable<int> Adjacents(int v) {
            IList<int> adjacents = new List<int>();
            for (var w = 0; w < V; w++)
                if (_edges[v,w]) adjacents.Add(w);
            return adjacents;
        }
        
        public override String ToString() {
            String text = "";
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
        //     IGraph g = new MatrixGraph(6);
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
        //     /*
        //       0: [1, 2]
        //       1: []
        //       2: [0, 3, 4]
        //       3: [4, 5]
        //       4: []
        //       5: [0, 3]
        //     */
        // }
    }
}