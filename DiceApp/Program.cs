using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DiceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dice roled. Guess what number it shows in 3 tries.");
            DiceGame diceGame = new DiceGame();
            diceGame.Run();

            Console.ReadKey();

        }
        class DiceApp
        {
            private Random _random = new Random();
                

            public int Roll()
            {
                return _random.Next(1,7);
            }
        }


        //This section get the guessed number
        public class Person
        {
            public int Guess()
            {
                Console.WriteLine("Enter a number: ");

                var diceInput = Console.ReadLine();

                if (int.TryParse(diceInput, out int convertedDiceInput))
                {
                    return convertedDiceInput;
                }
                Console.WriteLine("please input a valid number");

                return -1;
            }
        }

        public class DiceGame
        {
            private DiceApp _diceApp;
            private Person _person;
            private int _counter = 3;
            private bool _isTrue = false;

            public DiceGame()
            {
                _diceApp = new DiceApp();
                _person = new Person();
            }


            public void Run() 
            {
                do 
                { 

                    int diceAccess = _diceApp.Roll();
                    int personAccess = _person.Guess();

                    if (diceAccess == personAccess)
                    {
                        Console.WriteLine("you won!!");
                        _isTrue = true;
                    }
                    else if (diceAccess != personAccess)
                    {
                        Console.WriteLine("Wrong Number");
                        Console.WriteLine($"you have less than: {_counter - 1} attemps!!");
                        _counter--;

                    }
                    else if (personAccess < 1 || personAccess > 6)
                    {
                        Console.WriteLine("please make sure your input is above 1 or below 6");
                    }
                    else
                    {
                        Console.WriteLine("please input a valid number");
                    }
                } while (_counter > 0 || _isTrue);

                if (!_isTrue)
                {
                    Console.WriteLine("you lost :(");
                }
            }

        }
    }
}
