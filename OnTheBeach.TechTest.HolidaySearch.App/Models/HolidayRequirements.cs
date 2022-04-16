namespace OnTheBeach.TechTest.HolidaySearch.App.Models;

public class HolidayRequirements
{
    public List<string> DepartureAirports { get; set; }
    public string DestinationAirport { get; set; }
    public DateTime DepartureDate { get; set; }
    public int Duration { get; set; }
}