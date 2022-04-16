using System.Linq;
using OnTheBeach.TechTest.HolidaySearch.App;
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

        // Assert
        flights.Count().ShouldBeGreaterThan(0);
        flights.Count().ShouldBeEquivalentTo(12);
    }
    
    [Fact]
    public void ShouldLoadHotelsFromJsonData()
    {
        // Arrange
        
        // Act
        var hotels = _dataLoader.GetHotels();

        // Assert
        hotels.Count().ShouldBeGreaterThan(0);
        hotels.Count().ShouldBeEquivalentTo(13);
    }
}