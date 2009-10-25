/*******************************
 * Code adopted from Paul's post 
 * http://adventuresdotnet.blogspot.com/2009/09/creating-your-own-ioc-container-part-2.html
 * *******************************/
using System;


namespace CreateYourOwnIoCWithDI
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceLocator.Register<ILogger, ConsoleLogger>();
            ServiceLocator.Register<IMyInterface, MyClass>();

            MyMethod();

            Console.ReadKey();
        }

        private static void MyMethod()
        {
            IMyInterface obj = ServiceLocator.Resolve<IMyInterface>();
            obj.DoSomething();
        }
    }

    internal class MyClass : IMyInterface
    {
        private readonly ILogger _logger;

        [Inject]
        public MyClass(ILogger logger)
        {
            _logger = logger;
        }

        public void DoSomething()
        {
            _logger.Log("This method actually does NOTHING. Absolutely NOTHING.");
        }
    }

    internal interface IMyInterface
    {
        void DoSomething();
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("{0}:{1}", DateTime.Now.ToString("yyMMddhhmmss"), message);
        }
    }

    public class ServiceLocator
    {
        private static ServiceResolver _instance = null;
        private static object _lock = new object();

        /// <summary>
        /// Gets a shared instance of the ServiceResolver.
        /// </summary>
        /// <returns>Returns the shared instance of a ServiceResolver, or a new one if it has not yet been accessed.</returns>
        private static ServiceResolver GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new ServiceResolver();


                return _instance;
            }
        }


        /// <summary>
        /// Binds an abstract type to a concrete implementation.
        /// </summary>
        /// <typeparam name="TFrom">The abstract type or interface to use as a key.</typeparam>
        /// <typeparam name="TTo">The implementation type to use as a value.</typeparam>
        public static void Register<TFrom, TTo>()
        {
            GetInstance().Register<TFrom, TTo>();
        }


        /// <summary>
        /// Gets an implementation of the given type.
        /// </summary>
        /// <typeparam name="T">The abstract type or interface to look up.</typeparam>
        /// <returns>Returns an implementation of the given type.</returns>
        public static T Resolve<T>()
        {
            return GetInstance().Resolve<T>();
        }


    }
}