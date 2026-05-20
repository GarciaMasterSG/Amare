using Amare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface ILiveFeed
    {
        Task<List<LiveFeedGetDTO>> GetLiveFeed(string weddingCode);

        Task PostLiveFeed(string fileName, string description, string weddingCode, string userName);
    }
}
