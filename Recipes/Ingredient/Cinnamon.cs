namespace UdemyCourse.Recipes
{
    public partial class Recipe
    {
        public class Cinnamon : Ingredient
        {
            public override int Id => 7;
            public override string Name => "Cinnamon";
            public override string PreparationInstruction => $"Cinnamon. {base.PreparationInstruction} ";

        }
    }
}
