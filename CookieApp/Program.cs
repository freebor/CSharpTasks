using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create a new cookie reciepe! Available ingredients are:");
            List<string> cookieIngredient = new List<string>()
            {
                "Wheat flour ",
                "Coconut flour",
                "Butter",
                "Chocolate",
                "Sugar",
                "Cardamom",
                "Cinnamon",
                "Cocoa powder",
            };

            int cookieCount = 1;
            foreach (var item in cookieIngredient)
            {
                Console.WriteLine($"{cookieCount} . {item}");
                cookieCount++;
            }

            //bool isTrue = false;
            List<string> addedIngredient = new List<string>();
            //do 
            //{
            //    Console.WriteLine("Add an ingredient by its Id or type anything else if finished.");
            //    var cookie = Console.ReadLine();
            //    if (!int.TryParse(cookie, out int cookieToInt) || cookieToInt < 1 || cookieToInt > cookieIngredient.Count)
            //    {
            //        isTrue = false;
            //    }   
                
            //} while(isTrue);

            //addedIngredient.Add(cookieIngredient[cookieToInt - 1]);
            //Console.WriteLine($"{cookieIngredient[cookieToInt - 1]} added...");
            Console.ReadKey();
        }

        public enum cookieEnums
        {
            WheatFlour = 1,
            CoconutFlour,
            Butter,
            Chocolate,
            Sugar,
            Cardamom,
            Cinnamon,
            CocoaPowder,
        }

        public abstract class CookieIgredient
        {
            public virtual string Name { get; set; }
            public abstract void Description();


        }

        public class WheatFlour : CookieIgredient
        {
            public override string Name => "Wheat flour";
            public override void Description() 
            { 
                Console.WriteLine("hello world"); 
            }
        }
        public class CoconutFlour : CookieIgredient
        {
            public override string Name => "Coconut flour";
            public override void Description() 
            { 
                Console.WriteLine("hello world"); 
            }
        }
        public class Butter : CookieIgredient
        {
            public override string Name => "Butter";
            public override void Description() 
            { 
                Console.WriteLine("hello world"); 
            }
        }
        public class Chocolate : CookieIgredient
        {
            public override string Name => "Chocolate";
            public override void Description() 
            { 
                Console.WriteLine("hello world"); 
            }
        }
        public class Sugar : CookieIgredient
        {
            public override string Name => "Sugar";
            public override void Description() 
            { 
                Console.WriteLine("hello world"); 
            }
        }
        public class Cardamom : CookieIgredient
        {
            public override string Name => "Cardamom";
            public override void Description() 
            { 
                Console.WriteLine("hello world"); 
            }
        }
        public class Cinnamon : CookieIgredient
        {
            public override string Name => "Cinnamon";
            public override void Description() 
            { 
                Console.WriteLine("hello world"); 
            }
        }
        public class CocoaPowder : CookieIgredient
        {
            public override string Name => "Cocoa powder";
            public override void Description() 
            { 
                Console.WriteLine("hello world"); 
            }
        }
    }
}