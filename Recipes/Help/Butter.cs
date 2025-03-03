namespace UdemyCourse.Recipes
{
    public partial class Recipe
    {
        public class Butter : Ingredient
        {
            public override int Id => 3;
            public override string Name => "Butter";
            public override string PreparationInstruction => $"Butter. {base.PreparationInstruction} ";
        }
    }
}
