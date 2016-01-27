using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ThreadSafeQueueImplementation<T>
    {
        private readonly object _lockObject = new object();
        private readonly List<T> _items = new List<T>();

        public bool IsEmpty()
        {
            lock (_lockObject)
            {
                return _items.Count == 0;
            }
        }

        public T Dequeue()
        {
            lock (_lockObject)
            {
                T result = _items[0];
                _items.RemoveAt(0);
                return result;
            }
        }

        public void Enqueue(T item)
        {
            lock (_lockObject)
            {
                _items.Add(item);

            }
        }
    }
}
