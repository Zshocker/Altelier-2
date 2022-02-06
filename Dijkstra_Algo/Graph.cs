using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dijkstra_Algo
{
    public class Graph
    {
		List<Vertex<NodeE>> G=new List<Vertex<NodeE>>();
		Dictionary<int,NodeE> nods=new Dictionary<int, NodeE>();
		NodeE Get_node(int id)
        {
            return nods[id];
        }
		List<NodeE> Get_neighbours(NodeE Sas)
        {
            List<NodeE> neighbors = new List<NodeE>();
            foreach (Vertex<NodeE> it in G)
            {
                NodeE ED;
                if ((ED = it.Neighbor(Sas))!=null)
                {
                    neighbors.Add(ED);
                }
            }
            return neighbors;
        }
        int lenght_between(NodeE idSource, NodeE idDest)
        {
            foreach (Vertex<NodeE> i in G)
            {
                int a;
                if ((a = i.Distance(idSource, idDest)) != Vertex<NodeE>.infinity)
                {
                    return a;
                }
            }
            return Vertex<NodeE>.infinity;
        }
        public Graph(List<Vertex<NodeE>> g, List<NodeE> nods)
        {
            G = g;
            foreach (NodeE Id in nods)
            {
                this.nods.Add(Id.id,Id);
            }
        }

        public void Dijskistra(int id_source,out Dictionary<NodeE,NodeE> prev)
        {
            MyPriority_Queue <NodeE> Q=new MyPriority_Queue<NodeE>();
            prev=new Dictionary<NodeE, NodeE>();
            NodeE Source = Get_node(id_source);
            foreach (NodeE iterator in nods.Values)
            {
                iterator.dist_Source = Vertex<NodeE>.infinity;
                prev.Add(iterator,null);
                Q.add(iterator);
            }
            Source.dist_Source = 0;
            while (!Q.isEmpty())
            {
                NodeE U = Q.peek();
                Q.pop();
                U.visited=true;
                List<NodeE> neis = Get_neighbours(U);
                foreach (NodeE it in neis)
                {
                    if (!it.visited)
                    {
                        int temp = U.dist_Source + lenght_between(U, it);
                        if (temp < it.dist_Source)
                        {
                            it.dist_Source=temp;
                            prev[it] = U;
                        }
                    }
                }
            }
        }
        public Vertex<NodeE> Vertex_between(NodeE idSource, NodeE idDest)
        {
            return G.Find(s => (s.nodeDep==idSource && idDest==s.nodeArr));
        }
    }
}
