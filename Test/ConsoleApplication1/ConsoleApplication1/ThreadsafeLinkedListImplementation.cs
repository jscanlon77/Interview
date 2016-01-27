namespace ConsoleApplication1
{
    public class ThreadsafeLinkedListImplementation<T>
    {
        // 1.) declare the lock object
        // 2.) declare a current node of t and the node head
        private readonly object _syncLock = new object();
        private Node<T> _current;
        private Node<T> _head;

        // 3.) create the constructor with the head = null and count = 0
        public ThreadsafeLinkedListImplementation()
        {
            Count = 0;
            _head = null;
        }

        public int Count { get; private set; }

        // 4.) Implement the add method
        /*
            increment the count
            create a new node with content
            if the head is null then make the head the content as its the first node
            else fill the next node with content 
            make the current node hold the content as well
        */
        public void Add(T content)
        {
            lock (_syncLock)
            {
                Count++;
                var node = new Node<T>
                {
                    NodeContent = content
                };

                if (_head == null)
                {
                    _head = node;
                }
                else
                {
                    _current.Next = node;
                }

                _current = node;
            }
        }

        /// <summary>
        /// The retrieve node by position
        /// lock the operation
        /// assign temp node with the head
        /// create a return node
        /// create a while loop to loop through to see if the tempNode
        /// if the count is equal to the position -1
        /// then assign retNode = tempNode
        /// and tempNode = tempNode.Next;
        /// and return the node in that correct position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Node<T> Retrieve(int position)
        {
            lock (_syncLock)
            {
                var tempNode = _head;
                Node<T> retNode = null;
                var count = 0;
                while (tempNode != null)
                {
                    if (count == position - 1)
                    {
                        retNode = tempNode;
                        tempNode = tempNode.Next;
                    }
                }

                return retNode;
            }
        }

        public bool Delete(int position)
        {
            lock (_syncLock)
            {
                if (position == 1)
                {
                    _head = null;
                    _current = null;
                    return true;
                }

                if (position > 1 && position <= Count)
                {
                    var tempNode = _head;
                    Node<T> lastNode = null;
                    var count = 0;


                    while (tempNode != null)
                    {
                        if (count == position - 1)
                        {
                            if (lastNode != null)
                            {
                                lastNode.Next = tempNode.Next;
                                return true;
                            }

                            count++;
                            lastNode = tempNode;
                            tempNode = tempNode.Next;
                        }
                    }
                }

                return false;
            }
        }

        // Create the node class.
        public class Node<T>
        {
            public Node<T> Next;
            public T NodeContent;
        }
    }
}