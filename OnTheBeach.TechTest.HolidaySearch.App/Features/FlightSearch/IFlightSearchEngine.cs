using OnTheBeach.TechTest.HolidaySearch.App.Models;

namespace OnTheBeach.TechTest.HolidaySearch.App.Features.FlightSearch;

public interface IFlightSearchEngine
{
    IEnumerable<Flight> SearchFlights(IEnumerable<Flight> availableFlights, HolidayRequirements requirements);
}