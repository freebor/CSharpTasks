using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace CookieRecipeAppUsingLINQ
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
            if (cookieSessions.Any())
            {
                cookieSessions
                    .Select((session, index) => new { Session = session, Index = index })
                    .ToList()
                    .ForEach(session =>
                    {
                        Console.WriteLine($"-----{session.Index + 1}-----");
                        session.Session
                            .Select(id => cookieIngredient.ElementAtOrDefault(id - 1))
                            .Where(ingredent => ingredent != null)
                            .ToList()
                            .ForEach(ingredient => Console.WriteLine(ingredient));
                    });
            }


            Console.WriteLine("Create a new cookie reciepe! Available ingredients are:");
            //display my available list of all cookies

            cookieIngredient
                .Select((ingredient, index) => $"{index + 1} . {ingredient.Name}")
                .ToList()
                .ForEach(Console.WriteLine);

            //validation of user input
            bool isTrue;
            do
            {
                Console.WriteLine("Add an ingredient by its Id or type anything else if finished.");
                var cookie = Console.ReadLine();
                isTrue = int.TryParse(cookie, out int cookieToInt) && cookieToInt > 0 && cookieToInt <= cookieIngredient.Count;
                if (isTrue)
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

            if (cookiesSavedId.Any())
            {
                cookieSessions.Add(cookiesSavedId);
            }


            // sending data from cookie list to json
            File.WriteAllText(jsonFilePath, JsonSerializer.Serialize(cookieSessions));

            //printing the selected cookie reciepe
            Console.WriteLine("\n Reciepe Added: ");
            listForSavingInputedIngredient
                .Select((item) => $"{item.Name}. {item.Description} add to other ingredients.")
                .ToList()
                .ForEach(Console.WriteLine);

            //or 

            //listForSavingInputedIngredient.ForEach(ingredient => Console.WriteLine($"{ingredient.Name}. {ingredient.Description} add to other ingredients."));

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