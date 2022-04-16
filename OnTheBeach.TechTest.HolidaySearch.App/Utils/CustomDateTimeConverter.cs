using Newtonsoft.Json.Converters;

namespace OnTheBeach.TechTest.HolidaySearch.App.Utils;

public class CustomDateTimeConverter : IsoDateTimeConverter
{
    public CustomDateTimeConverter()
    {
        base.DateTimeFormat = "yyyy-MM-dd";
    }
}