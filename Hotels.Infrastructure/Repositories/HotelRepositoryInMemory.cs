using Hotels.Core.Domain;
using Hotels.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Infrastructure.Repositories
{
    public class HotelRepositoryInMemory : IHotelRepository
    {

        public Task<Hotel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
