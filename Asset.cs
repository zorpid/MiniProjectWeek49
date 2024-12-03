// See https://aka.ms/new-console-template for more information
public class Asset
{
    public Asset(string brand ,string modelName, DateTime buyDate, double price)
    {
        ModelName = modelName;
        BuyDate = buyDate;
        Price = price;
        Brand = brand;
    }

    public string ModelName { get; set; }
    public DateTime BuyDate { get; set; }
    public double Price { get; set; }
    public int EndOfLifeYears { get; set; } = 3; // 3 years
    public string Brand {  get; set; }




    public void PrintAssetDetails()
    {
        Console.WriteLine($"Model: {ModelName}");
        Console.WriteLine($"Purchase Date: {BuyDate.ToShortDateString()}");
        Console.WriteLine($"Price: {Price:C}");
        Console.WriteLine($"End of Life: {EndOfLifeYears} years");
        Console.WriteLine();
    }
}
