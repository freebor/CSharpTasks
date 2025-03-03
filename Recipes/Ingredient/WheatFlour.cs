namespace UdemyCourse.Recipes
{
    public partial class Recipe
    {
        public class WheatFlour : Ingredient
        {
            public override int Id => 1;
            public override string Name => "WheatFlour";
            public override string PreparationInstruction => $"WheatFlour. {base.PreparationInstruction} ";

        }
    }
}
