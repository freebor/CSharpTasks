using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace CookieApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFilePath = "cookie_ingredient.txt";

            List<CookieIngredient> cookieIngredient = new List<CookieIngredient>
            {
                new WheatFlour(),
                new CoconutFlour(),
                new Butter(),
                new Chocolate(),
                new Sugar(),
                new Cardamom(),
                new Cinnamon(),
                new CocoaPowder(),
            };
            List<CookieIngredient> listForSavingInputedIngredient = new List<CookieIngredient>();
            List<int> cookiesSavedId = new List<int>();
            List<List<int>> cookieSessions = new List<List<int>>();



            //get all the list of ID'S in the json file 
            if (File.Exists(jsonFilePath)) 
            {
                string jsonCookie = File.ReadAllText(jsonFilePath);
                //create an empty list of pre-existing cookin ingredient from json file
                cookieSessions = JsonSerializer.Deserialize<List<List<int>>>(jsonCookie);

            }
            for (int i = 0; i < cookieSessions.Count; i++)
            {
                Console.WriteLine($"------{i + 1}------");
                foreach (var item in cookieSessions[i])
                {
                    //find the Id in the cookie ingredient list to know what type of cookie ingredient it is
                    Console.WriteLine(cookieIngredient[item - 1]);
                }

            }



            Console.WriteLine("Create a new cookie reciepe! Available ingredients are:");
            //display my beginning list of all cookies
            int cookieCount = 1;
            foreach (var item in cookieIngredient)
            {
                Console.WriteLine($"{cookieCount} . {item.Name}");
                cookieCount++;
            }

            //validation of user input
            bool isTrue;
            do
            {
                Console.WriteLine("Add an ingredient by its Id or type anything else if finished.");
                var cookie = Console.ReadLine();
                isTrue = int.TryParse(cookie, out int cookieToInt) && cookieToInt > 0 && cookieToInt <= cookieIngredient.Count;
                if(isTrue)
                {
                    listForSavingInputedIngredient.Add(cookieIngredient[cookieToInt - 1]);
                    cookiesSavedId.Add(cookieToInt);
                }
                else
                {
                    Console.WriteLine("\nInvalid Selection, Displaying all Selected Cookie Ingredient...");
                }

            } while (isTrue);


            //adding the id's in the current section to my list of arrays
            if(cookiesSavedId.Count > 0)
            {
                cookieSessions.Add(cookiesSavedId);
            }

            // sending data from cookie list to json
            File.WriteAllText(jsonFilePath, JsonSerializer.Serialize(cookieSessions));

            //printing the selected cookie reciepe
            Console.WriteLine("\n Reciepe Added: ");
            foreach (var item in listForSavingInputedIngredient)
            {
                Console.WriteLine($"{item.Name}. {item.Description}. add to other ingredients.");
                    
            }


            Console.ReadKey();
        }


        public abstract class CookieIngredient
        {
            public string Name { get; set; }
            public string Description { get; set; }
            protected CookieIngredient(string name, string description)
            {
                Name = name;
                Description = description;

            }
            public override string ToString() 
            {
                return $"{Name}. {Description}";
            }


        }

        public class WheatFlour : CookieIngredient
        {
            public WheatFlour() : base("Wheat flour", "discription") { }
            
        }

        public class CoconutFlour : CookieIngredient
        {
            public CoconutFlour() : base("Coconut flour", "discription") { }

        }

        public class Butter : CookieIngredient
        {
            public Butter() : base("Butter", "discription") { }
        }

        public class Chocolate : CookieIngredient
        {
            public Chocolate() : base("Chocolate", "discription") { }
        }
        public class Sugar : CookieIngredient
        {
            public Sugar() : base("Sugar", "discription") { }

        }

        public class Cardamom : CookieIngredient
        {
            public Cardamom() : base("Cardamom", "discription") { }
        }

        public class Cinnamon : CookieIngredient
        {
            public Cinnamon() : base("Cinnamon", "discription") { }

        }
        public class CocoaPowder : CookieIngredient
        {
            public CocoaPowder() : base("CocoaPowder", "discription") { }

        }
    }
}