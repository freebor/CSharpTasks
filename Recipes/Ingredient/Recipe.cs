using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCourse.Recipes
{
    public partial class Recipe
    {
        public IEnumerable<Ingredient> Ingredients { get; }

        public Recipe(List<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }
    }
}
