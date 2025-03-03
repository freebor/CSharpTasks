namespace UdemyCourse.Recipes
{
    public partial class Recipe
    {
        public class Sugar : Ingredient
        {
            public override int Id => 5;
            public override string Name => "Sugar";
            public override string PreparationInstruction => $"Sugar. {base.PreparationInstruction} ";

        }
    }
}
