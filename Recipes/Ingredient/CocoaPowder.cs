namespace UdemyCourse.Recipes
{
    public partial class Recipe
    {
        public class CocoaPowder : Ingredient
        {
            public override int Id => 8;
            public override string Name => "CocoaPowder";
            public override string PreparationInstruction => $"CocoaPowder. {base.PreparationInstruction} ";

        }
    }
}
