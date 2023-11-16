using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BlazorApp.Data;

public class RegentEntry
{
    private int? _startYear;
    private int? _endYear;

    [JsonPropertyName("id")] public string Id { get; set; }

    [JsonPropertyName("nm")] public string Name { get; set; }

    [JsonPropertyName("yrs")] public string Years { get; set; }

    public int? StartYear
    {
        get
        {
            var years = Years.Split("-");

            if (years[0] == string.Empty)
            {
                return null;
            }

            var startYear = int.Parse(years[0]);

            return _startYear = startYear;
        }
    }

    public int? EndYear
    {
        get
        {
            var years = Years.Split("-");

            if (years[1] == string.Empty)
            {
                return null;
            }

            var endYear = string.Equals(years[1], "present", StringComparison.InvariantCultureIgnoreCase)
                ? DateTime.UtcNow.Year
                : int.Parse(years[1]);

            return _endYear = endYear;
        }
    }

    [JsonPropertyName("hse")] public string House { get; set; }

    public int GetYearsActive()
    {
        if (StartYear is null || EndYear is null)
        {
            return 0;
        }

        return EndYear.Value - StartYear.Value;
    }

    public string GetFirstName()
    {
        return Name.Split(" ")[0];
    }
}