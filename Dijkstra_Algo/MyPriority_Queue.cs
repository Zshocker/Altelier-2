using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_Algo
{
	class MyPriority_Queue<T>
	{
		private List<T> inner_queue;
		public MyPriority_Queue()
		{
			inner_queue= new List<T>();
		}
		public void add(T Elem)
		{
			inner_queue.Add(Elem);
		}
		public void pop()
		{
			inner_queue.Remove(inner_queue.Min());
		}
		public T peek()
		{
			return inner_queue.Min();
		}
		public int size()
		{
			return inner_queue.Count;
		}
		public bool isEmpty()
		{
			return inner_queue.Count==0;
		}
    }
}
