using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dijkstra_Algo;
namespace Dijkistra_inteface
{
    class Gest_Ghraph
    {
       Dictionary<Vertex<NodeE>,ProgressBar> pairs=new Dictionary<Vertex<NodeE>, ProgressBar>();
       List<NodeE> vs = new List<NodeE>();
       public Gest_Ghraph()
       {}
       public void Add_Vertex(ProgressBar bar,int dep,int arr,int V)
       {
            bar.Value = 0;
            int iddep = vs.FindIndex(s => s.id == dep);
            if (iddep == -1) {
                vs.Add(new NodeE(dep));
                iddep = vs.FindIndex(s => s.id == dep);
            } 
            int idarr = vs.FindIndex(s => s.id == arr);
            if (idarr == -1) {
                vs.Add(new NodeE(arr));
                idarr = vs.FindIndex(s => s.id == arr);
            }
            pairs.Add(new Vertex<NodeE>(vs[iddep],vs[idarr], V), bar);
       }
        public void do_Dijk(int dep,int arr)
        {
            Graph graph=new Graph(pairs.Keys.ToList<Vertex<NodeE>>(),vs);
            graph.Dijskistra(dep, out Dictionary < NodeE,NodeE>  D);
            NodeE ddep = vs.Find(s => s.id == arr);
            while (true)
            {
                NodeE node = D[ddep];
                if (node == null) break;
                Vertex<NodeE> s=  graph.Vertex_between(node,ddep);
                pairs[s].Value = 1;
                ddep = node;
            }
        }
        
    }
}
