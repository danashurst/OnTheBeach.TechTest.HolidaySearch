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
using Xunit.Abstractions;

namespace OnTheBeach.TechTest.HolidaySearch.Tests;

public class HolidaySearchTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IDataLoader _dataLoader;
    private readonly IHolidaySearchEngine _holidaySearchEngine;

    public HolidaySearchTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
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
        var firstResult = matchedHolidays.First();

        // Assert
        firstResult?.Flight.Id.ShouldBe(2);
        firstResult?.Hotel.Id.ShouldBe(9);

        PrintOutput(firstResult, holidayRequirements);
    }
    
    [Fact]
    public void ShouldMatchTheCorrectHolidayForCustomer2()
    {
        // Arrange
        var availableFlights = _dataLoader.GetFlights();
        var availableHotels = _dataLoader.GetHotels();
        
        var holidayRequirements = new HolidayRequirements
        {
            DepartureAirports = new List<string> {"LTN", "LGW"},
            DestinationAirport = "PMI",
            DepartureDate = new DateTime(2023, 06, 15),
            Duration = 10
        };

        // Act
        var matchedHolidays = _holidaySearchEngine.SearchHolidays(availableFlights, availableHotels, holidayRequirements).ToList();
        var firstResult = matchedHolidays.First();

        // Assert
        firstResult?.Flight.Id.ShouldBe(6);
        firstResult?.Hotel.Id.ShouldBe(5);
        
        PrintOutput(firstResult, holidayRequirements);
    }
    
    [Fact]
    public void ShouldMatchTheCorrectHolidayForCustomer3()
    {
        // Arrange
        var availableFlights = _dataLoader.GetFlights();
        var availableHotels = _dataLoader.GetHotels();
        
        var holidayRequirements = new HolidayRequirements
        {
            DepartureAirports = new List<string> {},
            DestinationAirport = "LPA",
            DepartureDate = new DateTime(2022, 11, 10),
            Duration = 14
        };

        // Act
        var matchedHolidays = _holidaySearchEngine.SearchHolidays(availableFlights, availableHotels, holidayRequirements).ToList();
        var firstResult = matchedHolidays.First();

        // Assert
        firstResult?.Flight.Id.ShouldBe(7);
        firstResult?.Hotel.Id.ShouldBe(6);
        
        PrintOutput(firstResult, holidayRequirements);
    }
    
    private void PrintOutput(HolidaySearchResult? firstResult, HolidayRequirements holidayRequirements)
    {
        _testOutputHelper.WriteLine("Customer 1 Best Matching Result: ");
        _testOutputHelper.WriteLine("-----------------------------------");
        _testOutputHelper.WriteLine("Flight: ");
        _testOutputHelper.WriteLine($"Flight Id: {firstResult?.Flight.Id}");
        _testOutputHelper.WriteLine($"Departing From: {firstResult?.Flight.From}");
        _testOutputHelper.WriteLine($"Travelling to: {firstResult?.Flight.To}");
        _testOutputHelper.WriteLine($"Flight Price: £{firstResult?.Flight.Price}");
        _testOutputHelper.WriteLine("Hotel: ");
        _testOutputHelper.WriteLine($"Hotel Id: {firstResult?.Hotel.Id}");
        _testOutputHelper.WriteLine($"Hotel Name: {firstResult?.Hotel.Name}");
        _testOutputHelper.WriteLine(
            $"Hotel Price: £{firstResult?.Hotel.PricePerNight * holidayRequirements.Duration} (£{firstResult?.Hotel.PricePerNight}/nt.)");
        _testOutputHelper.WriteLine("Total: ");
        _testOutputHelper.WriteLine(
            $"Total Price: £{firstResult?.Flight.Price + (firstResult?.Hotel.PricePerNight * holidayRequirements.Duration)}");
        _testOutputHelper.WriteLine("-----------------------------------");
    }
}