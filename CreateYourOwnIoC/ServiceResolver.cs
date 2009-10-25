/*******************************
 * Code adopted from Paul's post 
 * http://adventuresdotnet.blogspot.com/2009/09/creating-your-own-ioc-container.html
 * *******************************/
using System;
using System.Collections.Generic;



namespace CreateYourOwnIoC
{
    /// </summary>
    public class ServiceResolver
    {
        private readonly Dictionary<Type, object> _store;
        private readonly Dictionary<Type, Type> _bindings;


        /// <summary>
        /// Default constructor; instantiates a new ServiceResolver object.
        /// </summary>
        public ServiceResolver()
        {
            _store = new Dictionary<Type, object>();
            _bindings = new Dictionary<Type, Type>();
        }


        /// <summary>
        /// Gets an implementation object of a registered abstract type or interface.
        /// </summary>
        /// <typeparam name="T">The registered abstract type or interface to look up.</typeparam>
        /// <returns>Returns an object of the given type.</returns>
        public T Resolve<T>()
        {
            // check for registration
            if (!_bindings.ContainsKey(typeof(T)))
                throw new InvalidOperationException(string.Format("Requested type {0} has not been registered.",
                                                                  typeof(T)));


            // get destination type
            Type dest = _bindings[typeof(T)];


            // check for already requested object
            if (_store.ContainsKey(dest))
                return (T)_store[dest];


            // create a new instance of this type
            var obj = (T)Activator.CreateInstance(dest);


            // add to store for future use
            _store.Add(dest, obj);


            return obj;
        }


        /// <summary>
        /// Registers a type with its corresponding implementation type.
        /// </summary>
        /// <typeparam name="TFrom">The abstract type or interface to use as a key.</typeparam>
        /// <typeparam name="TTo">The implementation type to use as a value.</typeparam>
        public void Register<TFrom, TTo>()
        {
            _bindings.Add(typeof(TFrom), typeof(TTo));
        }
    }
}