public class Syrup : Ingredient
{
    public string Flavor { get; set; }
    public Syrup(decimal NetWeight, string flavor) : base("Сироп", NetWeight)
    {
        Flavor = flavor;
    }
    public override string Name => "Сироп";
}