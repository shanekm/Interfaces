using System;

using InterfaceSegregationPrinciple.Example1;
using InterfaceSegregationPrinciple.Example3;

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
            SendInInterface(anotherClass);

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
            SendInInterface(s1);
            if (s1 is ISavable)
            {
                Console.WriteLine("s1 is ISavable");
            }

            // when running s1 is NOT IExtendedSavable because SomeClass does NOT implements IExtendedSavable
            if (s1 is IExtendedSavable)
            {
                Console.WriteLine("s1 is IExtendedSavable");
            }

            // Example 3 - Best Solution
            // Since UserConfigSettingsReaderWriter impelments both is I only needed a reader I could define it like so. Controller Injection!
            IUserConfigReader reader = new UserConfigSettingsReader();
            reader.GetTheme(); // has only access to methods it needs

            // OR Even Better use common implementation but still restrics access
            IUserConfigReader readerWriter = new UserConfigSettingsReaderWriter();
            readerWriter.GetTheme(); // has only access to methods it needs

            UserConfigSettingsReaderWriter config = new UserConfigSettingsReaderWriter();
            config.GetTheme();
            config.SetTheme("test");


            UserConfigSettingsReaderWriterBoth both = new UserConfigSettingsReaderWriterBoth();
            config.GetTheme();
            config.SetTheme("test");
        }

        public static void SendInInterface(ISavable savable)
        {
            if (savable is ISavable)
            {
                // do stuff
            }
        }
    }
}