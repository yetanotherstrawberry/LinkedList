using System;
using System.Collections.Generic;

namespace Collection
{
    public partial class LinkedList<T> : ICollection<T>
    {
        public int Count { get; private set; } = 0;
        public bool IsReadOnly => false;

        public void Add(T element)
        {
            if (Count >= int.MaxValue) throw new ArgumentOutOfRangeException(paramName: nameof(element));

            if (Head == null && Tail == null)
            {
                Head = new LinkedListObject(element);
                Tail = Head;
            }
            else if (Head == null || Tail == null)
                throw new MemberAccessException();
            else
            {
                var objectList = new LinkedListObject(element)
                {
                    Previous = Tail,
                };
                Tail.Next = objectList;
                Tail = Tail.Next;
            }

            Count++;
        }

        public bool Remove(T element)
        {
            LinkedListObject? listObject = GetListObject(element);
            if (listObject == null) return false;

            var prevElement = listObject.Previous;
            var nextElement = listObject.Next;

            if (prevElement != null) prevElement.Next = nextElement;
            else Head = nextElement;

            if (nextElement != null) nextElement.Previous = prevElement;
            else Tail = prevElement;

            Count--;
            return true;
        }

        public void Clear() => Clear(false);

        public void Clear(bool forceGarbageCollection)
        {
            Head = null;
            Tail = null;
            Count = 0;

            if (forceGarbageCollection)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public bool Contains(T element) => GetIndex(element).HasValue;

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex >= Count) throw new ArgumentOutOfRangeException(paramName: nameof(arrayIndex));
            var loop = GetListObject((uint)arrayIndex);

            while (arrayIndex < Count)
            {
                if (loop == null) throw new NullReferenceException();

                array[arrayIndex] = loop.Object;
                arrayIndex++;
                loop = loop.Next;
            }
        }
    }
}
