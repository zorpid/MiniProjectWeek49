// See https://aka.ms/new-console-template for more information
public class Asset
{
    public Asset(string brand ,string modelName, DateTime buyDate, double price, string office)
    {
        ModelName = modelName;
        BuyDate = buyDate;
        Price = price;
        Brand = brand;
        Office = office;

        SetCurrencyAndLocalPrice();
    }

    public string ModelName { get; set; }
    public DateTime BuyDate { get; set; }
    public double Price { get; set; }
    public int EndOfLifeYears { get; set; } = 3; // 3 years
    public string Brand {  get; set; }
    public string Office { get; set; }
    public double LocalPrice { get; set; }
    public string Currency { get; set; }



    private void SetCurrencyAndLocalPrice()
    {
        switch (Office)
        {
            case "USA":
                Currency = "USD";
                LocalPrice = Price;
                break;
            case "Spain":
                Currency = "EUR";
                LocalPrice = Price * 0.95; 
                break;
            case "Sweden":
                Currency = "SEK";
                LocalPrice = Price * 11; 
                break;
            default:
                Currency = "USD";
                LocalPrice = Price;
                break;
        }
    }

    public string GetStatus()
    {
        DateTime threeYearsMark = BuyDate.AddYears(EndOfLifeYears);
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
            return ""; // No status if more than 6 months away from 3 years
        }
    }
}
