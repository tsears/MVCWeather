using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace tsears.MVCWeather.Services.Weather
{
    [DataContract]
    public class ForecastResponse : IForecastResponse
    {
        [DataMember(Name = "latitude")]
        public decimal Latitude { get; set; }
        [DataMember(Name = "longitude")]
        public decimal Longitude { get; set; }
        [DataMember(Name = "timezone")]
        public string TimeZone { get; set; }
        [DataMember(Name = "currently")]
        public CurrentForecast Currently {get; set;}
        [DataMember(Name = "hourly")]
        public HourlyForecast Hourly { get; set; }
        [DataMember(Name = "daily")]
        public DailyForecast Daily { get; set; }
        [DataMember(Name = "alerts")]
        public Alert[] Alerts { get; set; }
        [DataMember(Name = "flags")]
        public Flags Flags { get; set; }
    }

    [DataContract]
    public class CurrentForecast
    {
        [DataMember(Name = "time")]
        public long Time { get; set; }
        [DataMember(Name = "summary")]
        public string Summary { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
        [DataMember(Name = "nearestStormDistance")]
        public int NearestStormDistance { get; set; }
        [DataMember(Name = "nearestStormBearing")]
        public int NearestStormBearing { get; set; }
        [DataMember(Name = "precipIntensity")]
        public double PrecipIntensity { get; set; }
        [DataMember(Name = "precipIntensityError")]
        public double PrecipIntensityError { get; set; }
        [DataMember(Name = "precipProbability")]
        public double PrecipProbability { get; set; }
        [DataMember(Name = "precipType")]
        public string PrecipType { get; set; }
        [DataMember(Name = "temperature")]
        public double Temperature { get; set; }
        [DataMember(Name = "apparentTemperature")]
        public double ApparentTemperature { get; set; }
        [DataMember(Name = "dewPoint")]
        public double DewPoint { get; set; }
        [DataMember(Name = "humidity")]
        public double Humidity { get; set; }
        [DataMember(Name = "windSpeed")]
        public double WindSpeed { get; set; }
        [DataMember(Name = "windBearing")]
        public int WindBearing { get; set; }
        [DataMember(Name = "visibility")]
        public double Visibility { get; set; }
        [DataMember(Name = "cloudCover")]
        public double CloudCover { get; set; }
        [DataMember(Name = "pressure")]
        public double Pressure { get; set; }
        [DataMember(Name = "ozone")]
        public double Ozone { get; set; }
    }

    [DataContract]
    public class HourlyForecast
    {
        [DataMember(Name = "summary")]
        public string Summary { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
        [DataMember(Name = "data")]
        public HourlyForecastData[] Data { get; set; }
    }

    [DataContract]
    public class HourlyForecastData
    {
        [DataMember(Name = "time")]
        public long Time { get; set; }
        [DataMember(Name = "summary")]
        public string Summary { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
        [DataMember(Name = "precipIntensity")]
        public double PrecipIntensity { get; set; }
        [DataMember(Name = "precipProbability")]
        public double PrecipProbability { get; set; }
        [DataMember(Name = "precipType")]
        public string PrecipType { get; set; }
        [DataMember(Name = "temperature")]
        public double Temperature { get; set; }
        [DataMember(Name = "apparentTemperature")]
        public double ApparentTemperature { get; set; }
        [DataMember(Name = "dewPoint")]
        public double DewPoint { get; set; }
        [DataMember(Name = "humidity")]
        public double Humidity { get; set; }
        [DataMember(Name = "windSpeed")]
        public double WindSpeed { get; set; }
        [DataMember(Name = "windBearing")]
        public int WindBearing { get; set; }
        [DataMember(Name = "visibility")]
        public double Visibility { get; set; }
        [DataMember(Name = "cloudCover")]
        public double CloudCover { get; set; }
        [DataMember(Name = "pressure")]
        public double Pressure { get; set; }
        [DataMember(Name = "ozone")]
        public double Ozone { get; set; }
    }

    [DataContract]
    public class DailyForecast
    {
        [DataMember(Name = "summary")]
        public string Summary { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
        [DataMember(Name = "data")]
        public DailyForecastData[] Data { get; set; }
    }

    [DataContract]
    public class DailyForecastData
    {
        [DataMember(Name = "time")]
        public long Time { get; set; }
        [DataMember(Name = "summary")]
        public string Summary { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
        [DataMember(Name = "sunriseTime")]
        public long SunriseTime { get; set; }
        [DataMember(Name = "sunsetTime")]
        public long SunsetTime { get; set; }
        [DataMember(Name = "moonPhase")]
        public double MoonPhase { get; set; }
        [DataMember(Name = "precipIntensity")]
        public double PrecipIntensity { get; set; }
        [DataMember(Name = "precipIntensityMax")]
        public double PrecipIntensityMax { get; set; }
        [DataMember(Name = "precipIntensityMaxTime")]
        public long PrecipIntensityMaxTime { get; set; }
        [DataMember(Name = "precipProbability")]
        public double PrecipProbability { get; set; }
        [DataMember(Name = "precipType")]
        public string PrecipType { get; set; }
        [DataMember(Name = "temperatureMin")]
        public double TemperatureMin { get; set; }
        [DataMember(Name = "temperatureMinTime")]
        public long TemperatureMinTime { get; set; }
        [DataMember(Name = "temperatureMax")]
        public double TemperatureMax { get; set; }
        [DataMember(Name = "temperatureMaxTime")]
        public long TemperatureMaxTime { get; set; }
        [DataMember(Name = "apparentTemperatureMin")]
        public double ApparentTemperatureMin { get; set; }
        [DataMember(Name = "apparentTemperatureMinTime")]
        public long ApparentTemperatureMinTime { get; set; }
        [DataMember(Name = "apparentTemperatureMax")]
        public double ApparentTemperatureMax { get; set; }
        [DataMember(Name = "apparentTemperatureMaxTime")]
        public long ApparentTemperatureMaxTime { get; set; }
        [DataMember(Name = "dewPoint")]
        public double DewPoint { get; set; }
        [DataMember(Name = "humidity")]
        public double Humidity { get; set; }
        [DataMember(Name = "windSpeed")]
        public double WindSpeed { get; set; }
        [DataMember(Name = "windBearing")]
        public int WindBearing { get; set; }
        [DataMember(Name = "visibility")]
        public double Visibility { get; set; }
        [DataMember(Name = "cloudCover")]
        public double CloudCover { get; set; }
        [DataMember(Name = "pressure")]
        public double Pressure { get; set; }
        [DataMember(Name = "ozone")]
        public double Ozone { get; set; }
    }

    [DataContract]
    public class Alert 
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "time")]
        public long Time { get; set; }
        [DataMember(Name = "expires")]
        public long Expires { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "uri")]
        public string Uri { get; set; }
    }

    [DataContract]
    public class Flags
    {
        [DataMember(Name = "sources")]
        public string[] Sources { get; set;}
        [DataMember(Name = "darksky-stations")]
        public string[] DarkskyStations { get; set;}
        [DataMember(Name = "lamp-stations")]
        public string[] LampStations { get; set;}
        [DataMember(Name = "isd-stations")]
        public string[] IsdStations { get; set;}
        [DataMember(Name = "madis-stations")]
        public string[] MadisStations { get; set;}
        [DataMember(Name = "units")]
        public string Units { get; set;}
    }
}
