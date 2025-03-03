namespace UdemyCourse.Recipes
{
    public partial class Recipe
    {
        public class CoconutFlour : Ingredient
        {
            public override int Id => 2;
            public override string Name => "CoconutFlour";
            public override string PreparationInstruction => $"CoconutFlour. {base.PreparationInstruction} ";

        }
    }
}
