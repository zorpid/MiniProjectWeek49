// See https://aka.ms/new-console-template for more information





// Add mobile 
// Addlaptops







// Sort and print by office and purchase date














public static class AssetFunctions
{
    public static void AddLaptop(List<Asset> assets)
    {
        Console.Write("Enter Brand: ");
        string brand = Console.ReadLine();

        Console.Write("Enter Model: ");
        string modelName = Console.ReadLine();

        // Validate Price Input
        double price = 0;
        while (true)
        {
            Console.Write("Enter Price in USD: ");
            string priceInput = Console.ReadLine();
            if (double.TryParse(priceInput, out price))
            {
                if (price < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Price cannot be negative. Please enter a valid number.");
                    Console.ResetColor();
                }
                else
                {
                    break; // Valid price entered, exit the loop
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid numeric value for the price.");
                Console.ResetColor();
            }
        }

        // Validate Office Input
        string office = "";
        while (true)
        {
            Console.Write("Enter Office (USA, Spain, Sweden): ");
            office = Console.ReadLine().Trim();

            if (office.Equals("USA", StringComparison.OrdinalIgnoreCase) ||
                office.Equals("Spain", StringComparison.OrdinalIgnoreCase) ||
                office.Equals("Sweden", StringComparison.OrdinalIgnoreCase))
            {
                break; // Valid office entered
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid office. Please enter one of the following: USA, Spain, Sweden.");
                Console.ResetColor();
            }
        }

        DateTime buyDate = DateTime.Now;

        // Create a new Laptop and add to the list
        Laptop laptop = new Laptop(brand, modelName, buyDate, price, office);
        assets.Add(laptop);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Laptop added successfully!");
        Console.ResetColor();
    }

    public static void AddMobile(List<Asset> assets)
    {
        Console.Write("Enter Brand: ");
        string brand = Console.ReadLine();

        Console.Write("Enter Model: ");
        string modelName = Console.ReadLine();

        // Validate Price Input
        double price = 0;
        while (true)
        {
            Console.Write("Enter Price in USD: ");
            string priceInput = Console.ReadLine();
            if (double.TryParse(priceInput, out price))
            {
                if (price < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Price cannot be negative. Please enter a valid number.");
                    Console.ResetColor();
                }
                else
                {
                    break; // Valid price entered, exit the loop
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid numeric value for the price.");
                Console.ResetColor();
            }
        }

        // Validate Office Input
        string office = "";
        while (true)
        {
            Console.Write("Enter Office (USA, Spain, Sweden): ");
            office = Console.ReadLine().Trim();

            if (office.Equals("USA", StringComparison.OrdinalIgnoreCase) ||
                office.Equals("Spain", StringComparison.OrdinalIgnoreCase) ||
                office.Equals("Sweden", StringComparison.OrdinalIgnoreCase))
            {
                break; // Valid office entered
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid office. Please enter one of the following: USA, Spain, Sweden.");
                Console.ResetColor();
            }
        }

        DateTime buyDate = DateTime.Now;

        // Create a new Mobile and add to the list
        Mobile mobile = new Mobile(brand, modelName, buyDate, price, office);
        assets.Add(mobile);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Mobile added successfully!");
        Console.ResetColor();
    }
}