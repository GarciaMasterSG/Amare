using Amare.Data;
using Amare.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class WeddingEvents
    {
        private readonly IWeddingEvents _weddingEvents;
       
        public WeddingEvents(IWeddingEvents weddingEvents)
        {
            _weddingEvents = weddingEvents;
        }

        public async Task<List<WeddingEventDomain>> GetWeddingEvents(string weddingCode)
        {
            return await _weddingEvents.GetWeddingEvents(weddingCode);
        }

        public async Task<int> WeddingEventPost(WeddingEventDomain weddingEvent, string weddingCode)
        {
            return await _weddingEvents.WeddingEventPost(weddingEvent, weddingCode);
        }

        public async Task DeleteWeddingEvent(int id)
        {
            await _weddingEvents.DeleteWeddingEvent(id);
        }
    }
}
