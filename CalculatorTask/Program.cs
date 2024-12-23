using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello");

            Console.WriteLine("Input the first number: ");
            var input1 = Console.ReadLine();
            int convertInput1 = int.Parse(input1);

            Console.WriteLine("Input the first number: ");
            var input2 = Console.ReadLine();
            int convertInput2 = int.Parse(input2);

            Console.WriteLine("What do you you want to do ?");
            Console.WriteLine("[A]dd Numbers");
            Console.WriteLine("[S]ubtract Numbers");
            Console.WriteLine("[M]ultiply Numbers");

            var arithmeticInput = Console.ReadLine().ToUpper();
            int convertArithmeticInput = int.Parse(input2);

            int SumOfNumbers(int total)
            {
                if (arithmeticInput == "A")
                {
                    var sum = convertInput1 + convertInput2;
                    Console.WriteLine(sum);
                }
                else if (arithmeticInput == "S")
                {
                    var sum = convertInput1 - convertInput2;
                    Console.WriteLine(sum);
                }
                else if (arithmeticInput == "M")
                {
                    var sum = convertInput1 * convertInput2;
                    Console.WriteLine("the answer is " + sum);
                }
                else
                {
                    Console.WriteLine("please input a valid character");
                }

                return total;
            }
            SumOfNumbers(convertArithmeticInput);


            Console.ReadKey();
        }
    }
}
