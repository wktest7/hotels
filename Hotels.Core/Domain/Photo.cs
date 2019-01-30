using System;
using System.Collections.Generic;
using System.Text;

namespace Hotels.Core.Domain
{
    public class Photo
    {
        public Guid PhotoId { get; set; }
        public string Path { get; set; }

        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }

        protected Photo()
        {

        }

        public Photo(Guid photoId, string path, Guid hotelId)
        {
            PhotoId = photoId;
            Path = path;
            HotelId = hotelId;
        }
    }
}
