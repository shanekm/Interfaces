using System;

namespace InterfaceSegregationPrinciple.Example1
{
    internal class AnotherClass : IExtendedSavable
    {
        public void Save(string saveName)
        {
            Console.WriteLine("IExtendedSavable");
        }

        public void Save()
        {
            Console.WriteLine("ISavable");
        }
    }
}