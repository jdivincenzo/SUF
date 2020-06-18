using System;
using Services.APIServices;

namespace APITest
{
    class Program
    {
        static void Main(string[] args)
        {
            new TestService().CreateAndChangeStudents();
            Console.WriteLine("Demo completed.");
            Console.ReadLine();
        }
    }
}
