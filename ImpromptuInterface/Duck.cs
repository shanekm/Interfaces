using System;

namespace ImpromptuInterface
{
    public class Duck : IDuck
    {
        public void Walk()
        {
            Console.WriteLine("Walk");
        }

        public void Swim()
        {
            Console.WriteLine("Swin");
        }

        public void Quack()
        {
            Console.WriteLine("Qwack");
        }
    }
}