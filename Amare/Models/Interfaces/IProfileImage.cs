using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IProfileImage
    {
        Task PostProfileImage(int userId, string fileName);

        Task<List<string>> GetProfileImage(int userId);
    }
}
