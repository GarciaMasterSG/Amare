using Amare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IWeddingEvents
    {
        Task<List<WeddingEventDomain>> GetWeddingEvents(string weddingCode);

        Task<int> WeddingEventPost(WeddingEventDomain weddingEvent, string weddingCode);

        Task DeleteWeddingEvent(int id);
    }
}
