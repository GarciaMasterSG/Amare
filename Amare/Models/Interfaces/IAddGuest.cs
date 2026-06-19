using Models;
using Amare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IAddGuest
    {
        Task<List<GuestsDomain>> GetGuest(string weddingCode);

        Task<int> AddGuestsPost(string guest, string weddingCode);

        Task DeleteAddGuests(int id);

        Task DeleteTable(string tableName, string weddingCode);
    }
}
