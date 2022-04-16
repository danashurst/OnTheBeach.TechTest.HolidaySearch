using OnTheBeach.TechTest.HolidaySearch.App.Models;

namespace OnTheBeach.TechTest.HolidaySearch.App.Features.FlightSearch;

public class FlightSearchEngine : IFlightSearchEngine
{
    public IEnumerable<Flight> SearchFlights(IEnumerable<Flight> availableFlights, HolidayRequirements requirements)
    {
        var flightCandidates = new List<Flight>();
        var availableFlightList = availableFlights.ToList();

        foreach (var departingAirport in requirements.DepartureAirports)
        {
            flightCandidates.AddRange(availableFlightList
                .Where(f => f.From == departingAirport)
                .Where(f => f.To == requirements.DestinationAirport)
                .Where(f => f.DepartureDate == requirements.DepartureDate)
            );
        }
        
        return flightCandidates.OrderBy(f => f.Price);
    }
}