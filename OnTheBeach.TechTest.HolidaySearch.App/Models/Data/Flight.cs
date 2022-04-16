using Newtonsoft.Json;
using OnTheBeach.TechTest.HolidaySearch.App.Utils;

namespace OnTheBeach.TechTest.HolidaySearch.App.Models;

public class Flight
{
    public int Id { get; set; }
    public string Airline { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public int Price { get; set; }

    [JsonProperty("departure_date")]
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime DepartureDate { get; set; }
}
