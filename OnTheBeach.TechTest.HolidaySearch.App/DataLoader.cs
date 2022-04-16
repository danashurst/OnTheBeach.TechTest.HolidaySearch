namespace OnTheBeach.TechTest.HolidaySearch.App;
public class DataLoader
{
    public IEnumerable<Flight> GetFlights()
    {
        var flights = JsonConvert.DeserializeObject<IList<Flight>>(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Data\Flights.json")));
        return flights;
    }

    public IEnumerable<Flight> GetHotels()
    {
        var flights = JsonConvert.DeserializeObject<IList<Flight>>(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Data\Hotels.json")));
        return flights;
    }
}
