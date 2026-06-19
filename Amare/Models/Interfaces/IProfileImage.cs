using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IProfileImage
    {
        Task PostProfileImage(ProfileImageDomain image);

        Task<List<string>> GetProfileImage(ProfileImageDomain userId);
    }
}
