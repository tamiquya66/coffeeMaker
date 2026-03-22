public class Water : Ingredient
{
    public Water(decimal NetWeight) : base("Вода", NetWeight)
    {
    }
    public override string Name => "Вода";
}