using OnTheBeach.TechTest.HolidaySearch.App.Models;

namespace OnTheBeach.TechTest.HolidaySearch.App.Features.FlightSearch;

public class FlightSearchEngine : IFlightSearchEngine
{
    public IEnumerable<Flight> SearchFlights(IEnumerable<Flight> availableFlights, HolidayRequirements requirements)
    {
        var flightCandidates = availableFlights
            .Where(f => f.From == requirements.DepartureAirport)
            .Where(f => f.To == requirements.DestinationAirport)
            .Where(f => f.DepartureDate == requirements.DepartureDate);

        return flightCandidates.OrderByDescending(f => f.Price);
    }
}