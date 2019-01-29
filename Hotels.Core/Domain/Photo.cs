using System;
using System.Collections.Generic;
using System.Text;

namespace Hotels.Core.Domain
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string Path { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

    }
}
