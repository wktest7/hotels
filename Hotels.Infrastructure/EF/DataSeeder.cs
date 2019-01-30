using Hotels.Core.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Infrastructure.EF
{
    public static class DataSeeder
    {
        public async static Task Seed(HotelsDbContext context, UserManager<AppUser> userMgr)
        {
            if (!context.Hotels.Any())
            {
                var rnd = new Random();

                var paths = new List<string>()
                {
                    "~/photos/pexels-photo-1501272.jpeg",
                    "~/photos/pexels-photo-271618.jpeg",
                    "~/photos/pexels-photo-338504.jpeg",
                    "~/photos/pexels-photo-60217.jpeg",
                    "~/photos/pexels-photo-895555.jpeg"
                };

                var appUsers = new List<AppUser>();
                var user1 = await userMgr.FindByNameAsync("user1");
                var user2 = await userMgr.FindByNameAsync("user2");
                appUsers.Add(user1);
                appUsers.Add(user2);


                var addresses = new List<Address>();
                addresses.Add(new Address(Guid.NewGuid(), "Baligród", "Podzamcze 8", "38-606", "333222111",
                    "https://e-nocleg.pl/nocleg,domkipodskalka.html",
                    Voivodeship.Subcarpathian, Region.Mountains));
                addresses.Add(new Address(Guid.NewGuid(), "Jasień", "Jasień 12", "38-700", "444555111",
                  "https://e-nocleg.pl/nocleg,jasionka.html",
                  Voivodeship.Subcarpathian, Region.Mountains));

                context.Addresses.AddRange(addresses);

                var hotelTypes = Enum.GetValues(typeof(HotelType));
                var hotels = new List<Hotel>();

                for (int i = 0; i < 20; i++)
                {
                    hotels.Add(new Hotel(Guid.NewGuid(), "Hotel " + i, "", rnd.Next(30, 250), rnd.Next(30, 250),
                        appUsers[rnd.Next(appUsers.Count)], addresses[rnd.Next(addresses.Count)],
                       (HotelType)hotelTypes.GetValue(rnd.Next(hotelTypes.Length)), paths[rnd.Next(paths.Count)]));
                }
                context.Hotels.AddRange(hotels);

             
                var photos = new List<Photo>();
                for (int i = 0; i < 140; i++)
                {
                    photos.Add(new Photo(Guid.NewGuid(), paths[rnd.Next(paths.Count)],
                        hotels[rnd.Next(hotels.Count)].HotelId));
                }
                context.Photos.AddRange(photos);

                context.SaveChanges();
            }
        }
    }
}
