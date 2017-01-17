namespace tsears.MVCWeather.DataStructures {
    public class GeoCoordinate {
        public GeoCoordinate(string lat, string longC) {
            _lat = lat;
            _long = longC;
        }

        private string _lat;
        private string _long;

        public string Lat {
            get { return _lat; }
        }

        public string Long {
            get { return _long; }
        }
    }
}