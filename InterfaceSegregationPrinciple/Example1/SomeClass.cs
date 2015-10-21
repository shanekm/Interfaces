using System;

namespace InterfaceSegregationPrinciple.Example1
{
    internal class SomeClass : ISavable
    {
        public string Save()
        {
            Console.WriteLine("ISavable");
        }
    }
}