/*******************************
 * Code adopted from Paul's post 
 * http://adventuresdotnet.blogspot.com/2009/09/creating-your-own-ioc-container.html
 * *******************************/
namespace CreateYourOwnIoC
{
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