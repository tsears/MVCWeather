
namespace tsears.MVCWeather.Utils {
  interface IGeocoder {

    public void SetRequestUrl(string zip, string apiKey);
    public void SetRequestUrl(string city, string state, string apiKey);
    public void SetRequestUrl(string street, string city, string state, string apiKey);
    public void SetRequestUrl(string street, string city, string state, string country, string apiKey);
  }
}
