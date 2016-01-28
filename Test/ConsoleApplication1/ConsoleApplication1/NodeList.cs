using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication1
{
    
    public class NodeList<T>: Collection<Node<T>>
    {
        public NodeList():base()
        {
            
        }

        public NodeList(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
            {
                base.Items.Add(default(Node<T>));
            }
        }

        public Node<T> FindByValue(T value)
        {
            return Items.FirstOrDefault(node => node.Value.Equals(value));
        }
    }

    public class Node<T>
    {
        private T data;
        private NodeList<T> nodeList = new NodeList<T>();

        public Node()
        {
            
        }

        public Node(T data) : this(data, null) { }

        public Node(T data, NodeList<T> neighbours)
        {
            this.data = data;
            this.nodeList = neighbours;
        }

        public T Value
        {
            get { return data; }
            set { data = value; }
        }

        protected NodeList<T> NodeList
        {
            get { return nodeList; }
            set { nodeList = value; }
        }

    }
}
