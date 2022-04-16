using System;
using System.Linq;
using OnTheBeach.TechTest.HolidaySearch.App;
using OnTheBeach.TechTest.HolidaySearch.App.Models;
using OnTheBeach.TechTest.HolidaySearch.App.Utils.DataLoader;
using Shouldly;
using Xunit;

namespace OnTheBeach.TechTest.HolidaySearch.Tests;

public class HolidaySearchTests
{
    private readonly IDataLoader _dataLoader;
    private readonly IHolidaySearchEngine _holidaySearchEngine;
    
    public HolidaySearchTests(IDataLoader dataLoader, IHolidaySearchEngine holidaySearchEngine)
    {
        _dataLoader = dataLoader;
        _holidaySearchEngine = holidaySearchEngine;
    }

    [Fact]
    public void ShouldMatchTheCorrectHolidayForCustomer1()
    {
        // Arrange
        var availableFlights = _dataLoader.GetFlights();
        var availableHotels = _dataLoader.GetHotels();

        var holidayRequirements = new HolidayRequirements
        {
            DepartureAirport = "MAN",
            DestinationAirport = "AGP",
            DepartureDate = new DateTime(2023, 7, 1),
            Duration = 7
        };

        // Act
        var matchedHolidays = _holidaySearchEngine.SearchHolidays(availableFlights, availableHotels, holidayRequirements).ToList();

        // Assert
        matchedHolidays.First().Flight.Id.ShouldBe(2);
        matchedHolidays.First().Hotel.Id.ShouldBe(9);
    }
}