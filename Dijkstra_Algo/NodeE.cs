using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_Algo
{
	public class NodeE : IComparable
	{
		public int id { get; }
		public int dist_Source { get; set; } = 0;
		public bool visited { get; set; } = false;
		public NodeE(int id)
		{
			this.id = id;
		}
		public static bool operator <(NodeE E1,NodeE E2 ) {
			return E1.dist_Source < E2.dist_Source;
		}
		public static bool operator >(NodeE E1,NodeE E2) {
			return E1.dist_Source > E2.dist_Source;
		}
        public override string ToString()
        {
			return id + "      " + dist_Source;
		}
        public override bool Equals(object obj)
        {
            return id==((NodeE)obj).id;
        }
        public override int GetHashCode()
        {
            return id;
        }

        public int CompareTo(object obj)
        {
			if (Equals((NodeE)obj)) return 0;
			if (this > (NodeE)obj) return 1;
			return -1;
        }
    }
}
