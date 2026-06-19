using Amare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IAuth
    {
        Task<List<UserProfileDomain>> Login(string email);

        Task<List<UserProfileDomain>> UsersInWeddings(string email);

        Task SignUpBG(SignupPostDTO request, string hashedPassword);

        Task SignUpG(UserProfileDomain user, string hashedPassword);
    }
}
