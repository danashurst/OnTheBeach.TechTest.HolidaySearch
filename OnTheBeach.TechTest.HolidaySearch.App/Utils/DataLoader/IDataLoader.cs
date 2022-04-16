using OnTheBeach.TechTest.HolidaySearch.App.Models;

namespace OnTheBeach.TechTest.HolidaySearch.App.Utils.DataLoader;

public interface IDataLoader
{
    IEnumerable<Flight> GetFlights();
    IEnumerable<Hotel> GetHotels();
}