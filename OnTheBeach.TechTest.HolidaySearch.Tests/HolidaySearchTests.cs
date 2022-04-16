using System;
using System.Collections.Generic;
using System.Linq;
using OnTheBeach.TechTest.HolidaySearch.App;
using OnTheBeach.TechTest.HolidaySearch.App.Features.FlightSearch;
using OnTheBeach.TechTest.HolidaySearch.App.Features.HotelSearch;
using OnTheBeach.TechTest.HolidaySearch.App.Models;
using OnTheBeach.TechTest.HolidaySearch.App.Utils.DataLoader;
using Shouldly;
using Xunit;

namespace OnTheBeach.TechTest.HolidaySearch.Tests;

public class HolidaySearchTests
{
    private readonly IDataLoader _dataLoader;
    private readonly IHolidaySearchEngine _holidaySearchEngine;

    public HolidaySearchTests()
    {
        _dataLoader = new DataLoader();
        FlightSearchEngine flightSearchEngine = new ();
        HotelSearchEngine hotelSearchEngine = new ();
        _holidaySearchEngine = new HolidaySearchEngine(hotelSearchEngine, flightSearchEngine);
    }

    [Fact]
    public void ShouldMatchTheCorrectHolidayForCustomer1()
    {
        // Arrange
        var availableFlights = _dataLoader.GetFlights();
        var availableHotels = _dataLoader.GetHotels();
        
        var holidayRequirements = new HolidayRequirements
        {
            DepartureAirports = new List<string> {"MAN"},
            DestinationAirport = "AGP",
            DepartureDate = new DateTime(2023, 7, 1),
            Duration = 7
        };

        // Act
        var matchedHolidays = _holidaySearchEngine.SearchHolidays(availableFlights, availableHotels, holidayRequirements).ToList();

        // Assert
        matchedHolidays.First()?.Flight.Id.ShouldBe(2);
        matchedHolidays.First()?.Hotel.Id.ShouldBe(9);
    }
}