using System;

namespace ImpromptuInterface
{
    internal class Program
    {
        // 1. dynamic keyword
        // 2. Impromptu NuGet library
        // 3. Mixins Re-mix, Re-motion
        // 4. Extension methods

        // When a class does NOT implement an interface however you want to treat it like it would
        // you can use further versatility. But the class MUST contain the method signature you're trying to run

        // Dynamic keyword implementation
        // Impromtu Interface - ActLike<T> - pass in class (Swan) and receive Interface (IDuck) instan
        private static void Main(string[] args)
        {
            // Dynamic
            Swan swan = new Swan();
            DoDuckLikeThings(swan);

            //Impromptu interface
            var impromptuSwan = Impromptu.ActLike<IDuck>(swan);
            if (impromptuSwan != null)
            {
                impromptuSwan.Walk();
                impromptuSwan.Swim();
                impromptuSwan.Quack();
            }

            // Extension methods
            // able to use new Fly extension method
            Duck duck = new Duck();
            duck.Fly(1);
        }

        private static void DoDuckLikeThings(dynamic ducklish)
        {
            if (ducklish != null)
            {
                ducklish.Walk();
                ducklish.Swim();
                ducklish.Quack();
            }
        }
    }

    public static class MyInterfaceExtensions
    {
        public static void Fly(this IDuck target, int someInt)
        {
            Console.WriteLine("In extension methods " + someInt);
        }
    }
}