﻿namespace PostDemoApp.Models
{
    public class AddressModel
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public GeoLocationModel Geo { get; set; }

        public AddressModel()
        {

        }
    }
}
