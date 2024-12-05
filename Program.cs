// See https://aka.ms/new-console-template for more information



List<Asset> assets = new List<Asset>();


// Add mobile 
assets.Add(new Mobile("iPhone", "9", new DateTime(2022, 4, 5), 999, "Spain"));
assets.Add(new Mobile("Samsung", "9", new DateTime(2021, 7, 23), 850, "USA"));
assets.Add(new Mobile("Nokia", "9", new DateTime(2020, 11, 13), 300, "Sweden"));
// Addlaptops
assets.Add(new Laptop("MacBook", "9", new DateTime(2022, 3, 15), 1200, "USA"));
assets.Add(new Laptop("Asus", "9", new DateTime(2021, 8, 10), 800, "USA"));
assets.Add(new Laptop("Lenovo", "9", new DateTime(2020, 12, 1), 700, "USA"));
assets.Add(new Laptop("Lenovo", "9", new DateTime(2024, 12, 1), 700, "Sweden"));


var sortedByType = SortByType(assets);
PrintAssetList(sortedByType, "Asset Sorted by Type Details:");

// Sort and print by office and purchase date
var sortedByOfficeAndDate = SortByOfficeAndDate(assets);
PrintAssetList(sortedByOfficeAndDate, "Asset Sorted by Office/Buydate Details:");


while (true)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Add a Laptop");
    Console.WriteLine("2. Add a Mobile");
    Console.WriteLine("3. Print Assets Sorted by Type");
    Console.WriteLine("4. Print Assets Sorted by Office and Purchase Date");
    Console.WriteLine("5. Quit");
    Console.Write("Enter your choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AssetFunctions.AddLaptop(assets);
            break;
        case "2":
            AssetFunctions.AddMobile(assets);
            break;
        case "3":
            var sortedByTypeList = SortByType(assets);
            PrintAssetList(sortedByTypeList, "Asset Sorted by Type Details:");
            break;
        case "4":
            var sortedByOfficeAndDateList = SortByOfficeAndDate(assets);
            PrintAssetList(sortedByOfficeAndDateList, "Asset Sorted by Office/Buydate Details:");
            break;
        case "5":
            Console.WriteLine("Exiting the program. Goodbye!");
            return;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice. Please enter a valid option (1-5).");
            Console.ResetColor();
            break;
    }
}


static List<Asset> SortByType(List<Asset> assets)
{
    return assets
        .OrderBy(asset => asset.GetType() == typeof(Mobile) ? 1 : 0) // Laptops (0) before Mobiles (1)
        .ToList();
}

 static List<Asset> SortByOfficeAndDate(List<Asset> assets)
{
    return assets
        .OrderBy(asset => asset.Office) // Sort by Office
        .ThenBy(asset => asset.BuyDate) // Then by Purchase Date
        .ToList();
}



 static void PrintAssetList(List<Asset> assets, string header)
{
    Console.ResetColor();
    Console.WriteLine("\n" + header);
    Console.WriteLine("----------------------------------------------------------------");
    Console.WriteLine("Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Office".PadRight(15) +
                      "Purchase Date".PadRight(15) + "Price (USD)".PadRight(15) + "Price (Local)".PadRight(15));

    foreach (var asset in assets)
    {
        string assetType = asset.GetType().Name;
        string status = asset.GetStatus();

        // Set the console color based on status
        Console.ResetColor();
        if (status == "RED")
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (status == "YELLOW")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        // Print asset details with alignment
        Console.WriteLine(
            assetType.PadRight(15) +
            asset.Brand.PadRight(15) +
            asset.ModelName.PadRight(15) +
            asset.Office.PadRight(15) +
            asset.BuyDate.ToString("MM/dd/yyyy").PadRight(15) +
            asset.Price.ToString("F2").PadRight(15) +
            asset.LocalPrice + " " + asset.Currency.ToString().PadRight(15)
        );
    }
    Console.ResetColor();
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




