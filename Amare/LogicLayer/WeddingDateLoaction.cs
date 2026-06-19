using Amare.Data;
using Amare.Models;
using Microsoft.Data.SqlClient;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class WeddingDateLoaction
    {
        private readonly IWeddingDateLocation _weddingDateLocation;

        public WeddingDateLoaction(IWeddingDateLocation weddingDateLocation)
        {
            _weddingDateLocation = weddingDateLocation;
        }

        public async Task PostWeddingDateLocation(WeddingLocationAndDateDomain postDateLocation, string weddingCode)
        {
            await _weddingDateLocation.PostWeddingDateLocation(postDateLocation, weddingCode);
        }  
    }
}
