using System.Text.RegularExpressions;
using OnTheBeach.TechTest.HolidaySearch.App.Features.FlightSearch;
using OnTheBeach.TechTest.HolidaySearch.App.Features.HotelSearch;
using OnTheBeach.TechTest.HolidaySearch.App.Models;

namespace OnTheBeach.TechTest.HolidaySearch.App;

public class HolidaySearchEngine : IHolidaySearchEngine
{
    private readonly IHotelSearchEngine _hotelSearchEngine;
    private readonly IFlightSearchEngine _flightSearchEngine;

    public HolidaySearchEngine(IHotelSearchEngine hotelSearchEngine, IFlightSearchEngine flightSearchEngine)
    {
        _hotelSearchEngine = hotelSearchEngine;
        _flightSearchEngine = flightSearchEngine;
    }
    
    public IEnumerable<HolidaySearchResult?> SearchHolidays(IEnumerable<Flight> flights, IEnumerable<Hotel> hotels, HolidayRequirements holidayRequirements)
    {
        var matchedHotels = _hotelSearchEngine.SearchHotels(hotels, holidayRequirements).ToList();
        var matchedFlights = _flightSearchEngine.SearchFlights(flights, holidayRequirements).ToList();

        List<HolidaySearchResult?> searchResults = new ();
        foreach (var matchedHotel in matchedHotels)
        {
            if (matchedFlights.Count > 1)
            {
                searchResults.AddRange(
                    matchedFlights.Select(flight => new HolidaySearchResult
                    {
                        Hotel = matchedHotel, Flight = flight
                    }));
            }
            
            searchResults.Add(new HolidaySearchResult { Flight = matchedFlights.First(), Hotel = matchedHotel});
        }

        return searchResults.OrderBy( h => h.Flight.Price + (h.Hotel.PricePerNight * holidayRequirements.Duration) );
    }
}