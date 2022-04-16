using OnTheBeach.TechTest.HolidaySearch.App.Models;

namespace OnTheBeach.TechTest.HolidaySearch.App.Features.FlightSearch;

public class FlightSearchEngine : IFlightSearchEngine
{
    public IEnumerable<Flight> SearchFlights(IEnumerable<Flight> availableFlights, HolidayRequirements requirements)
    {
        var flightCandidates = availableFlights
            .Where(f => f.From == "MAN")
            .Where(f => f.To == "AGP")
            .Where(f => f.DepartureDate == new DateTime(2023, 7, 1));

        return flightCandidates.OrderByDescending(f => f.Price);
    }
}