using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    public partial class LinkedList<T> : IEnumerable<T>, IEnumerable
    {
        private class Enumerator : IEnumerator<T>
        {
            private readonly LinkedList<T> list;
            private int index = -1;

            public T Current
            {
                get
                {
                    try
                    {
                        if (index < 0) throw new IndexOutOfRangeException();
                        return list[(uint)index];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (Current == null) throw new InvalidOperationException();
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

            public Enumerator(LinkedList<T> list) => this.list = list;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator(this);

        public IEnumerator GetEnumerator() => new Enumerator(this);
    }
}
