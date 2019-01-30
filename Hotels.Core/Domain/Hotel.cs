using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotels.Core.Domain
{
    public class Hotel
    {
        private ISet<Photo> _photos = new HashSet<Photo>();

        public Guid HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PriceMin { get; set; }
        public int PriceMax { get; set; }
        //public DateTime DateAdded { get; set; }
        //public DateTime? DateOfPromotion { get; set; }
        public string ThumbnailPath { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public HotelType HotelType { get; set; }
        public ICollection<Photo> Photos { get; set; }

        protected Hotel()
        {

        }

        public Hotel(Guid hotelId, string name, string description, int priceMin, int priceMax, 
              AppUser appUser, Address address, HotelType hotelType, string thumbnailPath)
        {
            HotelId = hotelId;
            Name = name;
            Description = description;
            PriceMin = priceMin;
            PriceMax = priceMax;
            AppUserId = appUser.Id;
            AddressId = address.AddressId;
            HotelType = hotelType;
            ThumbnailPath = thumbnailPath;
        }

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
