using Collection;
using System;

namespace LinkedList
{
    internal class DemoLinkedList
    {
        public static void Main()
        {
            var list = new LinkedList<int>
            {
                1,
                20,
                12,
            };
            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);
            Console.WriteLine(list[2]);

            Console.WriteLine();
            list.Remove(1);
            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);

            Console.WriteLine();
            list.Clear(forceGarbageCollection: true);
            list = new LinkedList<int>(1, 2, 3);
            for (uint i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);

            list.Clear();
            Console.WriteLine();
            Console.WriteLine(list.Count.ToString());

            Console.WriteLine();
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Add(1);
            foreach (var i in list)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}
