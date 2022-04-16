namespace OnTheBeach.TechTest.HolidaySearch.App.Models;

public class Flight
{
    public int Id { get; set; }
    public string Airline { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public int Price { get; set; }

    [JsonPropertyName("departure_date")]
    public string DepartureDate { get; set; }
}
