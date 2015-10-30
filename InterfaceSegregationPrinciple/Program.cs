using System;

using InterfaceSegregationPrinciple.Example1;

namespace InterfaceSegregationPrinciple
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // TAKE ONE
            // IProduct interace has all the properties for a dvd store
            // decimal Price { get; set; }
            // double Weight { get; set; }
            // int Stock { get; set; }
            // int RunningTime { get; set; }

            // Later manager comes and wants to sell t-shirts as well
            // However IProduct interface has RunningTime which doesn't pertain to t-shirts
            // it's better to have a new interface IMovie : implement IProduct

            // Dvd implements IMovie
            // Tshirt implements IProduct


            // Example2
            // Having a class that implements ISavable, a decision is made that I also need another property or method in AnotherClass.cs that implements ISavable
            // Instead of going through each class that implements ISavable and modyfing a code in SomeClass.cs 
            // I can simply extend interface and make changes in AnotherClass that implements IExtendedSavable

            // Extending Interface
            // Now I have two methods available (ISave.Save() and IExtendedSavable.Save())
            AnotherClass anotherClass = new AnotherClass();
            anotherClass.Save("Extended save!");
            anotherClass.Save(); // ISavable save called

            // I can define anotherClass because it DOES implement ISavable
            ISavable a1 = new AnotherClass();
            a1.Save();

            if (a1 is ISavable)
            {
                Console.WriteLine("a1 is ISavable");
            }

            // when running a1 is IExtendedSavable because AnotherClass implements IExtendedSavable
            if (a1 is IExtendedSavable)
            {
                Console.WriteLine("a1 is IExtendedSavable");
            }

            ISavable s1 = new SomeClass();
            if (s1 is ISavable)
            {
                Console.WriteLine("s1 is ISavable");
            }

            // when running s1 is NOT IExtendedSavable because SomeClass does NOT implements IExtendedSavable
            if (s1 is IExtendedSavable)
            {
                Console.WriteLine("s1 is IExtendedSavable");
            }
        }
    }
}