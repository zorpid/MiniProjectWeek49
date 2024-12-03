// See https://aka.ms/new-console-template for more information



List<Asset> assets = new List<Asset>();


// Add mobile 
assets.Add(new Mobile("iPhone", "9", new DateTime(2022, 4, 5), 999));
assets.Add(new Mobile("Samsung", "9", new DateTime(2021, 7, 23), 850));
assets.Add(new Mobile("Nokia", "9", new DateTime(2020, 11, 13), 300));
// Addlaptops
assets.Add(new Laptop("MacBook", "9", new DateTime(2022, 3, 15), 1200));
assets.Add(new Laptop("Asus", "9", new DateTime(2021, 8, 10), 800));
assets.Add(new Laptop("Lenovo", "9", new DateTime(2020, 12, 1), 700));





Console.WriteLine("Asset Tracking Details:");
Console.WriteLine("----------------------------------------------------------------");
Console.WriteLine("Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) +
                          "Purchase Date".PadRight(15)) ;



foreach (var asset in assets)
{
    string assetType = asset.GetType().Name;  // Get the class name as the asset type

    Console.WriteLine(
        assetType.PadRight(15) +
        asset.Brand.PadRight(15) +
        asset.ModelName.PadRight(15) +
        asset.BuyDate.ToString("MM/dd/yyyy").PadRight(15)
    );
}





public class Laptop : Asset
{
    public Laptop(string brand, string modelName, DateTime buyDate, double price) : base(brand, modelName, buyDate, price)
    {
    }
}

public class Mobile : Asset
{
    public Mobile(string brand ,string modelName, DateTime purchaseDate, double price)
        : base(brand, modelName, purchaseDate, price) { }
}



