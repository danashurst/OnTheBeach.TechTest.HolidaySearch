using Newtonsoft.Json;
using OnTheBeach.TechTest.HolidaySearch.App.Models;

namespace OnTheBeach.TechTest.HolidaySearch.App.Utils.DataLoader;
public class DataLoader : IDataLoader
{
    public IEnumerable<Flight> GetFlights()
    {
        var flights = JsonConvert.DeserializeObject<IList<Flight>>(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Data/Flights.json")));
        return flights;
    }

    public IEnumerable<Hotel> GetHotels()
    {
        var hotels = JsonConvert.DeserializeObject<IList<Hotel>>(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Data/Hotels.json")));
        return hotels;
    }
}
