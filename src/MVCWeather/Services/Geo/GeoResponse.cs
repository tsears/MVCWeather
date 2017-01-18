using System.Runtime.Serialization;

namespace tsears.MVCWeather.Services.Geo
{
    [DataContract]
    public class GeoResponse
    {
        [DataMember(Name = "input")]
        public Input Input { get; set; }
        
        [DataMember(Name = "results")]
        public Result[] Results{ get; set;}
        
    }

    [DataContract]
    public class Input {
        [DataMember(Name = "address_components")]
        AddressComponents AddressComponents { get; set; }
        [DataMember(Name = "formatted_address")]
        string FormattedAddress { get; set; }
    }



    [DataContract]
    public class Result
    {
        [DataMember(Name = "address_components")]
        public AddressComponents AddressComponents { get; set; }
        [DataMember(Name = "formatted_address")]
        public string FormattedAddress { get; set; }
        [DataMember(Name = "location")]
        public Location Location { get; set; }
        [DataMember(Name = "accuracy")]
        public double Accuracy { get; set; }
        [DataMember(Name = "accuracy_type")]
        public string AccuracyType { get; set; }
        [DataMember(Name = "source")]
        public string Source { get; set; }
    }

    [DataContract]
    public class AddressComponents
    {
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "county")]
        public string County { get; set; }
        [DataMember(Name = "state")]
        public string State { get; set; }
        [DataMember(Name = "zip")]
        public string Zip { get; set; }
        [DataMember(Name = "country")]
        public string Country { get; set; }
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