using System;

namespace InterfaceSegregationPrinciple.Example1
{
    internal class AnotherClass : IExtendedSavable
    {
        public string Save(string saveName)
        {
            Console.WriteLine("IExtendedSavable");
        }

        public string Save()
        {
            Console.WriteLine("ISavable");
        }
    }
}