using Collection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList
{
    internal class DemoLinkedList
    {
        public static void Main()
        {
            ICollection<int?> list = new LinkedListClass<int?>
            {
                1,
                20,
                12,
            };
            Console.WriteLine(list.First());
            Console.WriteLine(list.ElementAt(1));
            Console.WriteLine(list.Last());

            Console.WriteLine();
            list.Remove(1);
            Console.WriteLine(list.First());
            Console.WriteLine(list.Last());

            Console.WriteLine();
            ((LinkedListClass<int?>)list).Clear(forceGarbageCollection: true);
            var list2 = new LinkedListClass<int?>(1, 2, 3);
            for (uint i = 0; i < list.Count; i++)
                Console.WriteLine(list2[i]);

            list.Clear();
            Console.WriteLine();
            Console.WriteLine(list.Count.ToString());

            Console.WriteLine();
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Add(null);
            foreach (var i in list)
            {
                Console.WriteLine(i?.ToString() ?? "null");
            }
        }
    }
}
