public class Milk : Ingredient
{
    public string FatLevel { get; set; }
    public Milk(decimal NetWeight, string fatlevel = "3.2%") : base("Молоко", NetWeight)
    {
        FatLevel = fatlevel;
    }
    public override string Name => "Молоко";
}