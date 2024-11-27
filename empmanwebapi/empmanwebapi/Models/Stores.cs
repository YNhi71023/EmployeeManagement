namespace empmanwebapi.Models
{
    public class Province
    {
        public string province_code { get; set; }
        public string province_name { get; set; }
    }
    public class District
    {
        public string province_code { get; set; }
    }
    public class Ward
    {
        public string district_code { get; set; }
    }
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
        public int location_id { get; set; }
        public string location_code { get; set; }
        public string location_name { get; set; }
        public string location_address { get; set; }
        public string ward_code { get; set; }
        public string district_code { get; set; }
        public string province_code { get; set; }
        public int location_type_id { get; set; }
    }
    public class LocationCreate : LocationFilter
    {
        public float lat { get; set; }
        public float lng { get; set; }
        public string image_overview {  get; set; }
    }
    public class LocationUpdate : LocationCreate
    {
        public int location_id { get; set; }
    }
}

