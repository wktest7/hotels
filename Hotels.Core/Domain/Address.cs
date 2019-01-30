using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotels.Core.Domain
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Voivodeship Voivodeship { get; set; }
        public Region Region { get; set; }

        public Hotel Hotel { get; set; }

        protected Address()
        {

        }

        public Address(Guid addressId, string city, string street, string postalCode, string phone,
            string website, Voivodeship voivodeship, Region region)
        {
            AddressId = addressId;
            City = city;
            Street = street;
            PostalCode = postalCode;
            Phone = phone;
            Website = website;
            Voivodeship = voivodeship;
            Region = region;
        }

      
    }


    public enum Region
    {
        [Display(Name = "Sea")]
        Sea,

        [Display(Name = "Mountains")]
        Mountains,

        [Display(Name = "Lake")]
        Lake
    }

    public enum Voivodeship
    {
        [Display(Name = "Greater Poland")]
        GreaterPoland,

        [Display(Name = "Kuyavian-Pomeranian")]
        KuyavianPomeranian,

        [Display(Name = "Lesser Poland")]
        LesserPoland,

        [Display(Name = "Łódź")]
        Lodz,

        [Display(Name = "Lower Silesian")]
        LowerSilesian,

        [Display(Name = "Lublin")]
        Lublin,

        [Display(Name = "Lubusz")]
        Lubusz,

        [Display(Name = "Masovian")]
        Masovian,

        [Display(Name = "Opole")]
        Opole,

        [Display(Name = "Podlaskie")]
        Podlaskie,

        [Display(Name = "Pomeranian")]
        Pomeranian,

        [Display(Name = "Silesian")]
        Silesian,

        [Display(Name = "Subcarpathian")]
        Subcarpathian,

        [Display(Name = "Świętokrzyskie")]
        Swietokrzyskie,

        [Display(Name = "Warmian-Masurian")]
        WarmianMasurian,

        [Display(Name = "West Pomeranian")]
        WestPomeranian
    }
}
