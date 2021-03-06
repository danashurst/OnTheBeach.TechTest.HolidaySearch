using System;
using System.Collections.Generic;
using System.Linq;
using OnTheBeach.TechTest.HolidaySearch.App.Features.HotelSearch;
using OnTheBeach.TechTest.HolidaySearch.App.Models;
using OnTheBeach.TechTest.HolidaySearch.App.Utils.DataLoader;
using Shouldly;
using Xunit;

namespace OnTheBeach.TechTest.HolidaySearch.Tests;

public class HotelSearchTests
{
    private readonly IDataLoader _dataLoader;
    private readonly IHotelSearchEngine _hotelSearchEngine;
    
    public HotelSearchTests()
    {
        _dataLoader = new DataLoader();
        _hotelSearchEngine = new HotelSearchEngine();
    }
    
    [Fact]
    public void ShouldMatchCorrectHotelForCustomer1()
    {
        // Arrange
        var availableHotels = _dataLoader.GetHotels();
        
        // Act
        var holidayRequirements = new HolidayRequirements
        {
            DepartureAirports = new List<string> {"MAN"},
            DestinationAirport = "AGP",
            DepartureDate = new DateTime(2023, 7, 1),
            Duration = 7
        };

        var matchedHotels = _hotelSearchEngine.SearchHotels(availableHotels, holidayRequirements);

        // Assert
        matchedHotels.First().Id.ShouldBe(9);
    }
    
    [Fact]
    public void ShouldMatchCorrectHotelForCustomer2()
    {
        // Arrange
        var availableHotels = _dataLoader.GetHotels();
        
        // Act
        var holidayRequirements = new HolidayRequirements
        {
            DepartureAirports = new List<string> {"LTN", "LGW"},
            DestinationAirport = "PMI",
            DepartureDate = new DateTime(2023, 06, 15),
            Duration = 10
        };

        var matchedHotels = _hotelSearchEngine.SearchHotels(availableHotels, holidayRequirements);

        // Assert
        matchedHotels.First().Id.ShouldBe(5);
    }
    
    [Fact]
    public void ShouldMatchCorrectHotelForCustomer3()
    {
        // Arrange
        var availableHotels = _dataLoader.GetHotels();
        
        // Act
        var holidayRequirements = new HolidayRequirements
        {
            DepartureAirports = new List<string>(),
            DestinationAirport = "LPA",
            DepartureDate = new DateTime(2022, 11, 10),
            Duration = 14
        };

        var matchedHotels = _hotelSearchEngine.SearchHotels(availableHotels, holidayRequirements);

        // Assert
        matchedHotels.First().Id.ShouldBe(6);
    }
}