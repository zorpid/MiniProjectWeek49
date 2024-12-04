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
assets.Add(new Laptop("Lenovo", "9", new DateTime(2024, 12, 1), 700));





Console.WriteLine("Asset Tracking Details:");
Console.WriteLine("----------------------------------------------------------------");
Console.WriteLine("Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) +
                          "Purchase Date".PadRight(15)) ;


var orderedByType = assets.OrderBy(asset => asset.GetType() == typeof(Mobile) ? 1 : 0);

//var orderedByBrand = orderedByType.ThenBy(asset => asset.Brand);
List<Asset> sortedAssets = orderedByType.ToList();

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

Console.WriteLine("Asset Sorted Details:");
Console.WriteLine("----------------------------------------------------------------");
Console.WriteLine("Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) +
                          "Purchase Date".PadRight(15));

//foreach (var asset in sortedAssets)
//{
//    string assetType = asset.GetType().Name;  // Get the class name as the asset type

//    Console.WriteLine(
//        assetType.PadRight(15) +
//        asset.Brand.PadRight(15) +
//        asset.ModelName.PadRight(15) +
//        asset.BuyDate.ToString("MM/dd/yyyy").PadRight(15)
//    );
//}


foreach (var asset in sortedAssets)
{
    string assetType = asset.GetType().Name;
    string status = GetStatus(asset);
    Console.ResetColor();
    if (status == "RED")
    {
        Console.ForegroundColor = ConsoleColor.Red;

    }
    if (status == "YELLOW")
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

    }

    Console.WriteLine(
        assetType.PadRight(15) +
        asset.Brand.PadRight(15) +
        asset.ModelName.PadRight(15) +
        asset.BuyDate.ToString("MM/dd/yyyy").PadRight(15) +
        status
    );
    
}

 static string GetStatus(Asset asset)
{
    DateTime threeYearsMark = asset.BuyDate.AddYears(3);
    DateTime now = DateTime.Now;

    TimeSpan difference = threeYearsMark - now;

    if (difference.TotalDays <= 90) // Less than or equal to 3 months
    {
        return "RED";
    }
    else if (difference.TotalDays <= 180) // Less than or equal to 6 months
    {
        return "YELLOW";
    }
    else
    {
        return ""; // No status if more than 6 months
    }
}