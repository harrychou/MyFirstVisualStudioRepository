using System;
using System.Linq;
using System.Text;

namespace CreateYourOwnIoC
{
    internal class Program
    {
        #region Methods (1)

        // Private Methods (1) 

        private static void Main(string[] args)
        {
            //            ServiceLocator.Register<IMyInterface, MyImp1>();
            // Console.WriteLine(MyMethod());

            ServiceLocator.Register<IMyInterface, MyImp2>();
            Console.WriteLine(MyMethod());

            Console.ReadKey();
        }

        private static int MyMethod()
        {
            IMyInterface imp = ServiceLocator.Resolve<IMyInterface>();
            imp.DoSomething();
            return imp.DoSomething(3);
        }

        #endregion Methods
    }


    public static class Extension
    {
        public static string FirstCharacters(this string self, int numOfChars)
        {
            if (self == null)
                return "";
            if (self.Length < numOfChars)
                return self;
            return self
                .Replace(Environment.NewLine, " ")
                .Substring(0, numOfChars - 3) + "...";
        }
    }

    public interface IMyInterface
    {
        void DoSomething();
        int DoSomething(int i);
    }

    public class MyImp1 : IMyInterface
    {
        public void DoSomething()
        {
            Console.WriteLine("Do SOmething from " + this.GetType());
        }

        public int DoSomething(int i)
        {
            Console.WriteLine("Do SOmething with " + i + " from " + this.GetType());
            return i + i;
        }
    }

    public class MyImp2 : IMyInterface
    {
        public void DoSomething()
        {
            Console.WriteLine("Do SOmething from " + this.GetType());
        }

        public int DoSomething(int i)
        {
            Console.WriteLine("Do SOmething with " + i + " from " + this.GetType());
            return i * i;
        }
    }
}
