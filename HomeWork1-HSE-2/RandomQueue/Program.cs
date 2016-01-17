using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> queue = new MyQueue<int>();

            queue.Push(10);
            queue.Push(20);
            queue.Push(30);
            queue.Push(new int[] { 40, 50, 60 });

            Console.WriteLine("Elements in random order:");
            while (!queue.IsEmpty)
            {
                Console.WriteLine(queue.Pop());
            }
            Console.ReadKey();
        }
    }
}
