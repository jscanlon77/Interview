using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class ThreadSafeStack<T>
    {
        // 1.) declare lock object for synchronisation
        private readonly object _lockObject = new object();

        // 2.) create index field
        private int _index = -1;

        // 3.) create the list of T
        public ThreadSafeStack()
        {
            Elements = new List<T>();
        }

        // 4.) Declare length
        public int Length
        {
            get
            {
                lock (_lockObject)
                {
                    return _index + 1;
                }
            }
        }

        public List<T> Elements { get; set; }

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        // 5.) implement push method of T
        public void Push(T element)
        {
            lock (_lockObject)
            {
                Index++;
                Elements.Insert(Index, element);
            }
        }

        // 6.) Implement pop method returning T
        public T Pop()
        {
            lock (_lockObject)
            {
                if (Length < 1)
                {
                    throw new InvalidOperationException();
                }

                var element = Elements[Index];
                Index--;
                return element;
            }
        }

        // 7.) implmement peek method
        public T Peek()
        {
            lock (_lockObject)
            {
                if (Length < 1)
                {
                    throw new InvalidOperationException();
                }

                return Elements[Index];
            }
        }
    
    }
}