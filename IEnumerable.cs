using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    public partial class LinkedListClass<T> : IEnumerable<T>, IEnumerable
    {
        private class Enumerator : IEnumerator<T>
        {
            private readonly LinkedListClass<T> list;
            private int index = -1;

            public T Current
            {
                get
                {
                    if (index < 0) throw new IndexOutOfRangeException();
                    return list[(uint)index];
                }
            }

            object? IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                index++;
                if (index >= list.Count) return false;
                else return true;
            }

            public void Reset() => index = -1;

            public Enumerator(LinkedListClass<T> list) => this.list = list;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator(this);

        public IEnumerator GetEnumerator() => new Enumerator(this);
    }
}
