using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public class B
    {
        
    }

    public class D : B
    {
        
    }

    class Program
    {
        public static void Foo(int x = 0, int y = 1, string s = "abc")
        {
            Console.WriteLine(x + y + s);
        }

       
        public static object locker = new object();
        static void Main(string[] args)
        {
            // Type safety
            object o1 = new object(); // this is ok because we are instantiating the same type
            object o2 = new B(); // this is also ok because B inherits from system.object
            object o3 = new D(); // this is ok because D inherits from system.object
            object o4 = o3; // this is also ok
            B b1 = new B(); // this is ok because instantiating same object
            B b2 = new D(); // this is ok because D derives from B
            D d1 = new D(); // all ok
            //B b3 = new object(); - not ok because object doesn't derive from b
            // D d2 = new object(); - this is not ok because object doesn't derive from d either
            B b4 = d1; // this is ok because d is an instance of B
            // D d2 = b2 - this is not ok because b does not derive from B
            D d4 = (D) d1; // this is ok
            D d5 = (D) b2; // this is also ok because d derives from b and hence cast is ok
            //D db = (D) b1; // this will fail bedause B cannot be cast as D
            B b5 = (B) d1; // This will fail with a a runtime exception as object cannot be cast.
            B b6 = (D) b2; // this is ok

            var listOfOddNumbers = GetOddNumbers(11);
            foreach (var number in listOfOddNumbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            BinaryTreeNode<string> node = new BinaryTreeNode<string>("hello");
            node.Left = new BinaryTreeNode<string>("Left data");
            node.Right = new BinaryTreeNode<string>("Right data");
            BinaryTree<string> tree = new BinaryTree<string> {Root = node};
            var value = tree.Root.Left.Value;

            var doesContain = tree.Contains("Left data");
            var doesContainRight = tree.Contains("Right data");

            Puzzles puzzles = new Puzzles();
            puzzles.DoFizzBuzz();

            List<int> listOfInts = new List<int>() { 1, 8, 2, 7, 4, 6, 5, 9, 2, 5, 7, 4, 6 };
            var position = puzzles.GetPositionOfInt(listOfInts, 17);

            List<int> listOfNumbers = new List<int>() { 1, 8, 2, 7, 4, 6, 5, 9, 2, 5, 7, 4, 10,12,15,18,19, 20, 25,23, 31 };
            var result = puzzles.FindPrimeNumbersInArray(listOfNumbers);

            List<int> arrayOfNumbers = new List<int>() { 1, 8, 2, 7, 4, 6, 5, 9, 2, 5, 7, 4, 10, 12, 15, 18, 19, 20, 25, 23, 31 };
            var reverseResult = puzzles.ReverseArray(arrayOfNumbers);
            var manualReverse = puzzles.ReversArrayManually(arrayOfNumbers);


            Console.ReadLine();
        }

        public static IEnumerable<int> GetOddNumbers(int maxNumber)
        {
            List<int> oddSet = new List<int>();
            int num = 0;
            while (true)
            {
                num++;
                if (num%2 == 1)
                {
                    yield return num;
                }
                if (num >= maxNumber)
                {
                    yield break;
                }
            }
        } 
         
    }
}
