namespace UdemyCourse.Recipes
{
    public partial class Recipe
    {
        public class Cardamom : Ingredient
        {
            public override int Id => 6;
            public override string Name => "Cardamom";
            public override string PreparationInstruction => $"Cardamom. {base.PreparationInstruction} ";
        }
    }
}
