using Hotels.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Core.Repositories
{
    public interface IHotelRepository
    {
        Task<Hotel> GetAsync(int id);
        Task AddAsync(Hotel hotel);
        Task UpdateAsync(Hotel hotel);
        Task DeleteAsync(Hotel hotel);

    }
}
