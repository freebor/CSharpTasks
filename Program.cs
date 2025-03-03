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

            var cookiesReciepesApp = new CookiesRecipesApp(
                new RecipesRepository(),
                new RecipesConsoleUserInteraction());
            CookiesRecipesApp.Run();

            Console.ReadKey();
        }

        public class CookiesRecipesApp
        {
            private readonly IRecipesRepository _recipesRepository;
            private readonly IRecipesUserInteraction _recipesUserInteraction;

            public CookiesRecipesApp(
                IRecipesRepository recipesRepository,
                IRecipesUserInteraction recipesUserInteraction)
            {
                _recipesRepository = recipesRepository;
                _recipesUserInteraction = recipesUserInteraction;
            }
            public void Run()
            {
                var allRecipes = _recipesRepository.Read(filePath);
                _recipesUserInteraction.PrintExistingRecipes(allRecipes);

                _recipesUserInteraction.PromptToCreateRecipe();

                var ingredient = _recipesUserInteraction.ReadIngredientFromUser();

                if(ingredient.Count > 0)
                {
                    new recipes = new Recipe(ingredient);
                    allRecipes.Add(recipe);
                    _recipesRepository.Write(filePath, allRecipes);

                    _recipesUserInteraction.ShowMessage("Recipe Added: ");
                    _recipesUserInteraction.ShowMessage(recipesRepository.ToString());
                }
                else
                {
                    _recipesUserInteraction.ShowMessage(
                        "No ingredient have been selected. " +
                        "Reciepe will not be saved. ");
                }
                
                _recipesUserInteraction.Exit();
            }
        }
    }

    
    public interface RecipesConsoleUserInteraction : IRecipesUserInteraction
    {
        public void ShowMessage(string message);

        public void Exit();
    }

    public class RecipesConsoleUserInteraction
    {

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        public void Exit()
        {
            Console.WriteLine("Press Any Key to close..");
            Console.ReadKey();
        }
    }

    internal interface IRecipesRepository
    {
    }
    
    internal interface RecipesRepository : IRecipesRepository
    {
    }

}
