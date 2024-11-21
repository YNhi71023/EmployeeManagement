namespace empmanwebapi.Models
{
    public class LocationType
    {
        public string location_type_code { get; set; }
        public string location_type_name { get;set; }
    }
    public class LocationTypeUpdate : LocationType
    {
        public int location_type_id { get; set; }
    }
    public class LocationFilter
    {
        public string location_code { get; set; }
        public string location_name { get; set; }
        public string location_address { get; set; }
        public string ward_code { get; set; }
        public string district_code { get; set; }
        public string province_code { get; set; }
        public int location_type_id { get; set; }
    }
}

