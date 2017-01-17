using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace tsears.MVCWeather.Services.Geo
{
    [DataContract]
    public class GeoResponse
    {
        [DataMember(Name = "results")]
        public Result[] Results{ get; set;}
        
    }

    [DataContract]
    public class Result
    {
        [DataMember(Name = "location")]
        public Location Location { get; set;}
    }

    [DataContract]
    public class Location
    {
        [DataMember(Name = "lat")]
        public decimal Lat {get;set;}
        [DataMember(Name = "lng")]
        public decimal Long {get;set;}
    }
}