namespace LanguageFeatures.Models;
public class Product
{
    public string Name { get; set; } = string.Empty;
    public decimal? Price { get; set; }

#pragma warning disable CRRSP08 // A misspelled word has been found
    public bool NamebeginswithS => Name?[0] == 'S';
#pragma warning restore CRRSP08 // A misspelled word has been found

    public static Product?[] GetProducts()
    {
        Product kayak = new()
        {
            Name = "Kayak",
            Price = 275M
        };
        Product lifeJacket = new()
        {
            Name = "LifeJacket",
            Price = 48.95M,
        };

        return new Product?[]
        {
            kayak, lifeJacket, null
        };
    }

}
