using OnTheBeach.TechTest.HolidaySearch.App.Models;

namespace OnTheBeach.TechTest.HolidaySearch.App.Features.HotelSearch;

public class HotelSearchEngine : IHotelSearchEngine
{
    public IEnumerable<Hotel> SearchHotels(IEnumerable<Hotel> availableHotels, HolidayRequirements holidayRequirements)
    {
        var hotelCandidates = availableHotels
            .Where(h => h.LocalAirports.Contains(holidayRequirements.DestinationAirport))
            .Where(h => h.Nights == holidayRequirements.Duration)
            .Where(h => h.ArrivalDate == holidayRequirements.DepartureDate);

        return hotelCandidates.OrderBy(h => h.PricePerNight);
    }
}