using System;
using System.Collections.Generic;

namespace Collection
{
    public partial class LinkedListClass<T>
    {
        private class LinkedListObject
        {
            public T Object { get; private set; }
            public LinkedListObject? Next { get; set; } = null;
            public LinkedListObject? Previous { get; set; } = null;

            public LinkedListObject(T element) => Object = element;
        }

        private LinkedListObject? Head { get; set; } = null;
        private LinkedListObject? Tail { get; set; } = null;

        private LinkedListObject GetListObject(uint index)
        {
            if (index >= Count) throw new ArgumentOutOfRangeException(paramName: nameof(index));

            var listObject = Head;

            if (index < Count / 2)
            {
                for (int i = 0; i < index; i++)
                {
                    listObject = listObject?.Next;
                }
            }
            else
            {
                listObject = Tail;
                for (int i = Count - 1; i > index; i--)
                {
                    listObject = listObject?.Previous;
                }
            }

            if (listObject == null) throw new NullReferenceException();
            else return listObject;
        }

        private LinkedListObject? GetListObject(T element)
        {
            var loop = Head;

            while (loop != null)
            {
                if (element != null ? element.Equals(loop.Object) : loop.Object == null) return loop;
                else loop = loop.Next;
            }

            return null;
        }

        public T this[uint index] => GetListObject(index).Object;

        public uint? GetIndex(T element)
        {
            var loop = Head;
            uint index = 0;

            if (element == null)
            {
                while (true)
                {
                    if (loop == null) return null;
                    else if (loop.Object == null) break;
                    index++;
                    loop = loop.Next;
                }
            }
            else
            {
                while (true)
                {
                    if (loop == null) return null;
                    else if (element.Equals(loop.Object)) break;
                    index++;
                    loop = loop.Next;
                }
            }

            return index;
        }

        private void AddElements(IEnumerable<T> elements)
        {
            foreach (T element in elements) Add(element);
        }

        public LinkedListClass() { }
        public LinkedListClass(IEnumerable<T> objects) => AddElements(objects);
        public LinkedListClass(params T[] objects) => AddElements(objects);

    }
}
