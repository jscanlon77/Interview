using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Puzzles
    {
        public void DoFizzBuzz()
        {
            Enumerable.Range(1, 100).Select(CalculateFizz)
                        .ToList()
                        .ForEach(Console.WriteLine);

            // Get the position of an integer in an array
           
        }

        public int GetPositionOfInt(List<int> listOfInts, int theInt)
        {

            for (int i = 0; i < listOfInts.Count; i++)
            {
                if (listOfInts.ElementAt(i) == theInt)
                {
                    return i + 1;
                }
            }

            return 0;
        }

        private string CalculateFizz(int n)
        {
            if (n%15 == 0)
            {
                return "FizzBuzz";
            }
            if (n%3 == 0)
            {
                return "Fizz";
            }

            return n%5 == 0 ? "Buzz" : n.ToString();
        }

        public IEnumerable<int> FindPrimeNumbersInArray(List<int> listOfNumbers)
        {
            List<int> primes = new List<int>();
            foreach (int number in listOfNumbers)
            {
                for (int i = 1; i <= number; i++)
                {
                    bool isPrime = true; // Move initialization to here
                    for (int j = 2; j < i; j++) // you actually only need to check up to sqrt(i)
                    {
                        if (i % j == 0) // you don't need the first condition
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        if (!primes.Contains(i))
                        {
                            primes.Add(i);
                        }
                    }
                }
            }

            return primes;
        }

        public IEnumerable<int> ReverseArray(List<int> arrayOfNumbers)
        {
            return Enumerable.Reverse(arrayOfNumbers);
        }

        public IEnumerable<int> ReversArrayManually(List<int> arrayOfNumbers)
        {
            for (int i = 0; i < (arrayOfNumbers.Count / 2); i++)
            {
                int other = arrayOfNumbers.Count - i - 1;
                int temp = arrayOfNumbers[i];
                arrayOfNumbers[i] = arrayOfNumbers[other];
                arrayOfNumbers[other] = temp;
            }

            return arrayOfNumbers;
        }
    }
}
