using Amare.Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Home
    {
        private readonly IHome _home;

        public Home(IHome home)
        {
            _home = home;
        }

        public async Task<WeddingDomain> GetIndex(string weddingCode)
        {
            var couple = await _home.GetIndex(weddingCode);

            var coupleName = couple.FirstOrDefault(x => x.WeddingCode == weddingCode);

            return coupleName;
        }

    }
}
