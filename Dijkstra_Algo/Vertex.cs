
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Vertex<T>
{
	public static int infinity = 30000;
	public T nodeDep { get; private set; }
	public T nodeArr { get; private set; }
	int Lenght;
	public Vertex()
	{

	}
	public Vertex(T nodD, T nodA, int len)
	{
		nodeDep = nodD;
		nodeArr = nodA;
		Lenght = len;
	}
	public static bool operator <( Vertex<T> A,Vertex<T> A2){
		return	A.Lenght < A2.Lenght;
	}
	public static bool operator >( Vertex<T> A,Vertex<T> A2){
		return A.Lenght > A2.Lenght;
	}
	public bool is_Dep(T node)
    {
		return node.Equals(nodeDep);
	}
	public T Neighbor(T node)
    {
		if (is_Dep(node))
		{
			return nodeArr;
		}
		return nodeDep;
	}
	public int Distance(T id1, T id2)
	{
		if (id1.Equals(nodeDep) && id2.Equals(nodeArr))
		{
			return Lenght;
		}
		else
		{
			return infinity;
		}
	}
	public Vertex<T> Copy(){
		Vertex<T> Tas = new Vertex<T>(nodeDep, nodeArr, Lenght);
		return Tas;
	}
};
