using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotels.Core.Domain
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceMin{ get; set; }
        public decimal PriceMax { get; set; }
        //public DateTime DateAdded { get; set; }
        //public DateTime? DateOfPromotion { get; set; }
        public string ThumbnailPath { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public HotelType HotelType { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }


    public enum HotelType
    {
        [Display(Name = "Guesthouse")]
        Guesthouse,

        [Display(Name = "Summer house")]
        SummerHouse,

        [Display(Name = "Villa")]
        Villa,

        [Display(Name = "Apartament")]
        Apartament,

        [Display(Name = "Campsite")]
        Campsite,

    }
}
