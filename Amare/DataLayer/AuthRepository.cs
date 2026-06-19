using Amare.Data;
using Amare.Models;
using Microsoft.Data.SqlClient;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AuthRepository : IAuth
    {
        private readonly DbUserProfile _db;

        public AuthRepository(DbUserProfile db)
        {
            _db = db;
        }

        public async Task<List<UserProfileDomain>> Login(string email)
        {
            string query = "SELECT u.UserId, u.Email, u.Name, u.Password, u.Role, u.UserPoints, u.ProfilePhoto, w.WeddingCode FROM UserProfile u LEFT JOIN UsersInWeddings w ON u.Email = w.UserEmail WHERE u.Email = @Email;";

            List<SqlParameter> parameters = new List<SqlParameter> {
                new SqlParameter("@Email", email)
            };

            var users = await _db.GetQueryExecuter<UserProfileDomain>(query,
                    r => new UserProfileDomain
                    {
                        Id = Convert.ToInt16(r["UserId"]),
                        Name = Convert.ToString(r["Name"]),
                        Email = Convert.ToString(r["Email"]),
                        Password = Convert.ToString(r["Password"]),
                        ProfilePhoto = Convert.ToString(r["ProfilePhoto"]),
                        WeddingCode = Convert.ToString(r["WeddingCode"]),
                        Role = Convert.ToString(r["Role"]),
                        UserPoints = Convert.ToInt32(r["UserPoints"])
                    }, parameters);

            return users;
        }

        public async Task<List<UserProfileDomain>> UsersInWeddings(string email)
        {
            string query = "SELECT * FROM UserProfile WHERE Email = @Email";

            List<SqlParameter> parameters = new List<SqlParameter> {
                new SqlParameter("@Email", email)
            };

            var users = await _db.GetQueryExecuter<UserProfileDomain>(query,
                    r => new UserProfileDomain
                    {
                        Id = Convert.ToInt16(r["UserId"]),
                        Name = Convert.ToString(r["Name"]),
                        Email = Convert.ToString(r["Email"]),
                        Password = Convert.ToString(r["Password"]),
                        ProfilePhoto = Convert.ToString(r["ProfilePhoto"]),
                        Role = Convert.ToString(r["Role"]),
                        UserPoints = Convert.ToInt32(r["UserPoints"])
                    }, parameters);

            return users;
        }

        public async Task SignUpBG(SignupPostDTO request, string hashedPassword)
        {
            var queryCouple = "INSERT INTO Wedding(WeddingCode, Groom, Bride) VALUES (@WeddingCode, @Groom, @Bride); INSERT INTO UserProfile(Name, Email, Password, ProfilePhoto, Role) VALUES (@Name, @Email, @Password, @ProfilePhoto, @Role); " +
                "INSERT INTO Budget(WeddingCode, MaxBudget) VALUES (@WeddingCode, @MaxBudget);" +
                "INSERT INTO UsersInWeddings(UserEmail, WeddingCode) VALUES (@Email, @WeddingCode);";

            List<SqlParameter> parametersCouple = new List<SqlParameter>() {
                new SqlParameter("@Name", request.userProfile.Name),
                new SqlParameter("@Email", request.userProfile.Email),
                new SqlParameter("@Password", hashedPassword),
                new SqlParameter("@ProfilePhoto", request.userProfile.ProfilePhoto),
                new SqlParameter("@WeddingCode", request.userProfile.WeddingCode),
                new SqlParameter("@Role", request.userProfile.Role),
                new SqlParameter("@Groom", request.wedding.Groom),
                new SqlParameter("@Bride", request.wedding.Bride),
                new SqlParameter("@MaxBudget", request.maxBudget)
                };

            await _db.PatchDeleteQueryExecuter(queryCouple, parametersCouple);

            return;
        }

        public async Task SignUpG(UserProfileDomain user, string hashedPassword)
        {
            var queryGuest = "INSERT INTO UserProfile(Name, Email, Password, ProfilePhoto, Role) VALUES (@Name, @Email, @Password, @ProfilePhoto, @Role);" +
                "INSERT INTO UsersInWeddings(UserEmail, WeddingCode) VALUES (@Email, @WeddingCode)";

            List<SqlParameter> parametersGuest = new List<SqlParameter>() {
                new SqlParameter("@Name", user.Name),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", hashedPassword),
                new SqlParameter("@ProfilePhoto", user.ProfilePhoto),
                new SqlParameter("@WeddingCode", user.WeddingCode),
                new SqlParameter("@Role", user.Role),
            };

            await _db.PostQueryExecuter(queryGuest, parametersGuest);

            return;
        }
    }
}
