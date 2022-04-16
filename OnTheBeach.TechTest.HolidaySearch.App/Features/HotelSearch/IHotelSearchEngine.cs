using OnTheBeach.TechTest.HolidaySearch.App.Models;

namespace OnTheBeach.TechTest.HolidaySearch.App.Features.HotelSearch;

public interface IHotelSearchEngine
{
    IEnumerable<Hotel> SearchHotels(IEnumerable<Hotel> availableHotels, HolidayRequirements holidayRequirements);
}

public class HotelSearchEngine : IHotelSearchEngine
{
    public IEnumerable<Hotel> SearchHotels(IEnumerable<Hotel> availableHotels, HolidayRequirements holidayRequirements)
    {
        throw new NotImplementedException();
    }
}