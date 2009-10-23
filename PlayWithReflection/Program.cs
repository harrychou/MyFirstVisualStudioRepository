using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace PlayWithReflection
{
    public static class ExtensionMethods
    {
        public static void OutputToConsole(this string s)
        {
            Console.WriteLine(s);
        }

        public static void OutputToConsole(this string s, string format)
        {
            Console.WriteLine(format, s);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // GettingTypesConstructorsAndParameters();
            // GetTypesFromMsCorLib();

            //GettingTypeNames(typeof(Environment));
            //GettingTypeNames(typeof(Environment.SpecialFolder));
            //GettingTypeNames(typeof(IList<>));
            //GettingTypeNames(typeof(IList<int>));

            //foreach (var interfaceObj in typeof(IList<int>).GetInterfaces())
            //{
            //    // ICollection<> , IEnmerable<>, IEmurable
            //    interfaceObj.FullName.OutputToConsole();
            //}     

            Type openGenreic = typeof(List<>);
            Type closeGeneric = openGenreic.MakeGenericType(typeof(int));

            IList<int> intList = Activator.CreateInstance(closeGeneric) as List<int>;

            for (int i = 0; i < 3; i++)
            {
                intList.Add(i * i);
            }

            intList.Count.ToString().OutputToConsole();



            Console.ReadKey();
        }

        static void GettingTypeNames(Type type)
        {
            type.FullName.OutputToConsole();
            type.Namespace.OutputToConsole();
            type.Name.OutputToConsole();
        }

        static void GetTypesFromMsCorLib()
        {
            var assembly = Type.GetType("System.String").Assembly;
            assembly.GetName().FullName.OutputToConsole();

            foreach (var type in assembly.GetTypes().Where(x => x.Namespace != null && x.Namespace.Contains("System.Collection")))
            {
                type.FullName.OutputToConsole();
            }


            Type.GetType("System.String[]").FullName.OutputToConsole();
            typeof(IList<>).FullName.OutputToConsole(); // System.Collections.Generic.IList`1

            // typeof(IList<>).BaseType.FullName.OutputToConsole(); // will throw error since IList is an interface which does not have a base type
            // typeof (int).GetArrayRank(); // throw error: must be an array type
            typeof(int[]).GetArrayRank().ToString().OutputToConsole("this is my format {0}");
        }


        static void GettingTypesConstructorsAndParameters()
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
        }
    }

    public static class Extension
    {
    }

    public class Employer
    {
        int _i;

        public Employer(int i)
        {
            _i = i;
        }

        public string Name { get; set; }
    }

    public class Employee
    {
    }
}
