using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestBLL testBLL = new TestBLL();
            testBLL.DisplayAllMoviesOrdered();

            Console.ReadKey();
        }
    }
}
