using Amare.Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Auth
    {
        private readonly IAuth _auth;

        public Auth(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<List<UserProfileDomain>> Login(string username)
        {
            return await _auth.Login(username);
        }

        public async Task<List<UserProfileDomain>> UsersInWeddings(string email)
        {
            return await _auth.UsersInWeddings(email);
        }

        public async Task SignUpBG(SignupPostDTO request)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.userProfile.Password);

            await _auth.SignUpBG(request, hashedPassword);

            return;
        }

        public async Task SignUpG(UserProfileDomain request)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            await _auth.SignUpG(request, hashedPassword);

            return;
        }
    }

}
