using System.Collections.Generic;

namespace MiniProject4_Airline_Networks
{
    public interface IGraph
    {
        
        int V { get; }
        int E { get; }
        void AddEdge(int v, int w); // add an edge from vertice v to vertice w
            
        void AddUndirectedEdge(int v, int w) {
        AddEdge(v, w);
        AddEdge(w, v);
        }
        
        IEnumerable<int> Adjacents(int v); // list all adjacent vertices to vertice v
    }
}