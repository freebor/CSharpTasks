namespace UdemyCourse.Recipes
{
    public partial class Recipe
    {
        public abstract class Ingredient
        {
            public abstract int Id { get; } 
            public abstract string Name { get; }
            public virtual string PreparationInstruction => "Add Other Ingredient";
        }
    }
}
