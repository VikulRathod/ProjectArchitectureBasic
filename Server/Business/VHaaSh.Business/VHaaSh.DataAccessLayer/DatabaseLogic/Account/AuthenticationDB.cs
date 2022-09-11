using System.Data;
using System.Data.SqlClient;
using VHaaSh.DataAccessLayer.Interfaces.Account;
using VHaaSh.Models.Account;

namespace VHaaSh.DataAccessLayer.DatabaseLogic.Account
{
    public class AuthenticationDB : IAuthenticationDB
    {
        public int Register(User user)
        {
            using (SqlConnection con = new SqlConnection(DBConstants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(DBConstants.spRegister, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Email", user.Email);

                SqlParameter returnCode = new SqlParameter()
                {
                    ParameterName = "@ReturnCode",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(returnCode);

                con.Open();
                cmd.ExecuteNonQuery();

                return (int)returnCode.Value;
            }
            return -1;
        }

        public User Authenticate(User user)
        {
            User userInfo = new User() { UserName = user.UserName, Password = user.Password };

            using (SqlConnection con = new SqlConnection(DBConstants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(DBConstants.spAuthenticateUser, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                SqlParameter accountLocked = new SqlParameter()
                {
                    ParameterName = "@AccountLocked",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };

                SqlParameter authenticated = new SqlParameter()
                {
                    ParameterName = "@Authenticated",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };

                SqlParameter retryCount = new SqlParameter()
                {
                    ParameterName = "@RetryCount",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(accountLocked);
                cmd.Parameters.Add(authenticated);
                cmd.Parameters.Add(retryCount);

                con.Open();

                cmd.ExecuteNonQuery();

                userInfo.IsAccountLocked = (bool)accountLocked.Value;
                userInfo.IsAuthenticated = (bool)authenticated.Value;
                userInfo.RetryAttempts = (int)retryCount.Value;

                return userInfo;
            }
        }
    }
}