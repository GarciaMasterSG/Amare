using Amare.Models;
using Amare.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;

namespace LogicLayer
{
    public class AddGuests
    {

        private readonly IAddGuest _addGuest;

        public AddGuests(IAddGuest addGuest)
        {
            _addGuest = addGuest;
        }
        public async Task<List<GuestsDomain>> GetGuest(string weddingCode)
        {
            return await _addGuest.GetGuest(weddingCode);
        }

        public async Task<int> AddGuestsPost(string guest, string weddingCode)
        {
            return await _addGuest.AddGuestsPost(guest, weddingCode);
        }

        public async Task DeleteAddGuests(int id)
        {
            await _addGuest.DeleteAddGuests(id);
        }

        public async Task DeleteTable(string tableName, string weddingCode)
        {
            await _addGuest.DeleteTable(tableName, weddingCode);
        }

    }
}
