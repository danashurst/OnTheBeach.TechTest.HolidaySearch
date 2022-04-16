using System;
using System.Collections.Generic;
using System.Linq;
using OnTheBeach.TechTest.HolidaySearch.App;
using OnTheBeach.TechTest.HolidaySearch.App.Models;
using OnTheBeach.TechTest.HolidaySearch.App.Utils.DataLoader;
using Shouldly;
using Xunit;

namespace OnTheBeach.TechTest.HolidaySearch.Tests;

public class DataLoaderTests
{
    private readonly DataLoader _dataLoader;
    public DataLoaderTests()
    {
        _dataLoader = new DataLoader();
    }
    
    [Fact]
    public void ShouldLoadFlightsFromJsonData()
    {
        // Arrange
        
        // Act
        var flights = _dataLoader.GetFlights();

        var firstExpectedFlight = new Flight
        {
            Id = 1,
            Airline = "First Class Air",
            DepartureDate = new DateTime(2023, 7, 1),
            From = "MAN",
            Price = 470,
            To = "TFS"
        };
        
        // Assert
        flights.Count().ShouldBeGreaterThan(0);
        flights.Count().ShouldBeEquivalentTo(12);

        flights.First().ShouldBeEquivalentTo(firstExpectedFlight);
    }
    
    [Fact]
    public void ShouldLoadHotelsFromJsonData()
    {
        // Arrange
        
        // Act
        var hotels = _dataLoader.GetHotels();

        var firstExpectedHotel = new Hotel
        {
            Id = 1,
            Name = "Iberostar Grand Portals Nous",
            ArrivalDate = new DateTime(2022, 11, 5),
            PricePerNight = 100,
            LocalAirports = new List<string>
            {
                "TFS"
            },
            Nights = 7
        };

        // Assert
        hotels.Count().ShouldBeGreaterThan(0);
        hotels.Count().ShouldBeEquivalentTo(13);
        
        hotels.First().ShouldBeEquivalentTo(firstExpectedHotel);
    }
}