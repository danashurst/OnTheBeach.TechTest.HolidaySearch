using System;
using System.Linq;
using OnTheBeach.TechTest.HolidaySearch.App;
using OnTheBeach.TechTest.HolidaySearch.App.Features.FlightSearch;
using OnTheBeach.TechTest.HolidaySearch.App.Models;
using Shouldly;
using Xunit;

namespace OnTheBeach.TechTest.HolidaySearch.Tests;

public class FlightSearchTests
{
    private readonly IDataLoader _dataLoader;
    private readonly IFlightSearchEngine _flightSearchEngine;
    
    public FlightSearchTests()
    {
        _dataLoader = new DataLoader();
        _flightSearchEngine = new FlightSearchEngine();
    }
    
    [Fact]
    public void ShouldMatchTheCorrectFlightForCustomer()
    {
        // Arrange
        var availableFlights = _dataLoader.GetFlights();
        
        var holidayRequirements = new HolidayRequirements
        {
            DepartureAirport = "MAN",
            DestinationAirport = "APG",
            DepartureDate = new DateTime(2023, 7, 1),
            Duration = 7
        };

        // Act
        var flightMatches = _flightSearchEngine.SearchFlights(availableFlights, holidayRequirements);
        
        // Assert
        flightMatches.First().Id.ShouldBe(2);
    }
}