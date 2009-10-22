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
                Console.WriteLine("types ............... ");
                Console.WriteLine("type name: " + type.FullName);
                var constructors = type.GetConstructors();
                foreach (var constructor in constructors)
                {
                    Console.WriteLine("constructors ............... ");

                    var parameters = constructor.GetParameters();

                    Console.WriteLine("parameters ............... ");
                    foreach (var parameter in parameters)
                    {
                        Console.WriteLine(parameter.Name);
                    }
                }
            }

            Console.ReadKey();
        }
    }

    public static class Extension
    {
    }

    public class Employer
    {
        int _i;

        public Employer(int i) {
            _i = i;
        }

        public string Name { get; set; }
    }

    public class Employee
    {
    }
}
