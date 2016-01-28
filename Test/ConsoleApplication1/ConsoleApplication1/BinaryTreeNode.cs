namespace ConsoleApplication1
{
    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode()
        {
        }

        public BinaryTreeNode(T data) : base(data)
        {
        }

        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            Value = data;
            var children = new NodeList<T>(2)
            {
                [0] = left,
                [1] = right
            };

            base.NodeList = children;
        }

        public BinaryTreeNode<T> Left
        {
            get
            {
                return (BinaryTreeNode<T>) NodeList?[0];
            }
            set
            {
                if (NodeList == null)
                {
                    NodeList = new NodeList<T>(2);
                }
                NodeList[0] = value;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get
            {
                return (BinaryTreeNode<T>)NodeList?[1];
            }
            set
            {
                if (NodeList == null)
                {
                    NodeList = new NodeList<T>(2);
                }
                NodeList[1] = value;
            }
        }
    }
}