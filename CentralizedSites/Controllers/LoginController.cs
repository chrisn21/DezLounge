using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web.Http;

namespace CentralizedSites.Controllers
{
    public class LoginController : ApiController
    {
        public class UserProfile
        {
            public string Username;
            public string Password;
            public string Email;
        }

        readonly UserProfile[] _validUsers = new UserProfile[] 
        { 
            new UserProfile { Username = "MasterCrookz", Password = "pokemon", Email = "Kevin@Groceries.com" }, 
            new UserProfile { Username = "ChrisWin", Password = "DezLounge", Email = "DezChris@Groceries.com" }, 
            new UserProfile { Username = "SangOw", Password = "DezCrow", Email = "DezSang@Groceries.com" } 
        };

        [Route("DezApi/verify/")]
        [HttpPost]
        public bool VerifyAccount(UserProfile profile)
        {
            if (string.IsNullOrEmpty(profile.Username) || string.IsNullOrEmpty(profile.Password) || string.IsNullOrEmpty(profile.Email))
                return false;

            var verifyConnection = new SqlConnection("Data Source=Chris-PC;Initial Catalog=master;User ID=dezadmin;Password=123sqldez321");

            var query = "SELECT * from AccountProfiles where Username = '" + profile.Username + "' AND Password = '" + profile.Password + "' AND Email = '" + profile.Email + "'";
            var verify = new SqlCommand(query, verifyConnection);
            verifyConnection.Open();

            using (var results = verify.ExecuteReader())
            {
                return results.HasRows;
            }

            //return _validUsers.Any(vp => profile.Username.Equals(vp.Username) && profile.Password.Equals(vp.Password) && profile.Email.Equals(vp.Email));
        }
    }
}
