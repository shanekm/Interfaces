using System;
using System.Collections.Generic;

namespace IEnumerableProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Will always return 1
            Console.WriteLine(SimpleReturn());

            // yield return works, returns each line
            foreach (int i in YieldReturn())
            {
                Console.WriteLine(i);
            }

            // Example1
            SomeList someList = new SomeList();
            someList.Add(1);
            someList.Add(2);
            foreach (int item in someList)
            {
                // Will print out 1 and 2
                Console.WriteLine(item);
            }

            // Example2
            AnotherList anotherList = new AnotherList();
            anotherList.Add(1);
            anotherList.Add(2);
            foreach (int item in anotherList)
            {
                // Will print out 1 and 2
                Console.WriteLine(item);
            }
        }

        // When calling SimpleReturn() it will always return 1
        private static int SimpleReturn()
        {
            return 1;
            return 2;
            return 3;
        }

        // yield keyword preserves state of method, next return calls line below etc.
        private static IEnumerable<int> YieldReturn()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }
}