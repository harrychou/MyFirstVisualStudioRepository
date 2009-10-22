using System;
using System.Reflection;

namespace PlayWithReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine("type name: " + type.FullName);
            }

            Console.ReadKey();
        }
    }
}
