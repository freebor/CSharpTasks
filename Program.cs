using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCourse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                for(int p = 1; p < 50; p++)
                {
                    Console.WriteLine($"answer to the first loop is {i}, answer to the second loop is {p} ");
                }
            }
            Console.ReadKey();
        }
    }
}
