using OnTheBeach.TechTest.HolidaySearch.App.Models;

namespace OnTheBeach.TechTest.HolidaySearch.App;

public interface IHolidaySearchEngine
{
    IEnumerable<HolidaySearchResult?> SearchHolidays(IEnumerable<Flight> flights, IEnumerable<Hotel> hotels,
        HolidayRequirements holidayRequirements);
}