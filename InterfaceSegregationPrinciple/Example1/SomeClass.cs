using System;

namespace InterfaceSegregationPrinciple.Example1
{
    internal class SomeClass : ISavable
    {
        public void Save()
        {
            Console.WriteLine("ISavable");
        }
    }
}