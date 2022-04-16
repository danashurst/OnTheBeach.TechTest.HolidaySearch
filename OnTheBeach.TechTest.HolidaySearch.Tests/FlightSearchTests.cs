using System;
using System.Linq;
using OnTheBeach.TechTest.HolidaySearch.App;
using OnTheBeach.TechTest.HolidaySearch.App.Features.FlightSearch;
using OnTheBeach.TechTest.HolidaySearch.App.Models;
using OnTheBeach.TechTest.HolidaySearch.App.Utils.DataLoader;
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
    public void ShouldMatchTheCorrectFlightForCustomer1()
    {
        // Arrange
        var availableFlights = _dataLoader.GetFlights();
        
        var holidayRequirements = new HolidayRequirements
        {
            DepartureAirport = "MAN",
            DestinationAirport = "AGP",
            DepartureDate = new DateTime(2023, 7, 1)
        };

        // Act
        var flightMatches = _flightSearchEngine.SearchFlights(availableFlights, holidayRequirements);
        
        // Assert
        flightMatches.First().Id.ShouldBe(2);
    }
}