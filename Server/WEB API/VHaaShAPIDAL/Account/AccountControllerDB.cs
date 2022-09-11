using System.Data;
using System.Data.SqlClient;
using VHaaShAPIModals.Account;

namespace VHaaSh.API.DAL.Account
{
    public class AccountControllerDB : IAccountControllerDB
    {
        public AccountControllerDB() { }

        public int RegisterUser(string firstName, string lastName, string mobile, string email, string otp)
        {
            using (SqlConnection con = Connection.SqlConnectionObject)
            {
                SqlDataReader reader = ExecuteVHaaShDB.ExecuteReader(con, VHaaShDB.spRegisterUser,
                     new SqlParameter() { ParameterName = "@FirstName", Value = firstName },
                     new SqlParameter() { ParameterName = "@LastName", Value = lastName },
                     new SqlParameter() { ParameterName = "@Mobile", Value = mobile },
                     new SqlParameter() { ParameterName = "@Email", Value = email },
                     new SqlParameter() { ParameterName = "@Otp", Value = otp });


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return (int)reader[0];
                    }
                }
            }

            return -1;
        }

        public int ActivateRegisteredUser(string mobile, string password, string email, string otp)
        {
            using (SqlConnection con = Connection.SqlConnectionObject)
            {
                SqlDataReader reader = ExecuteVHaaShDB.ExecuteReader(con, VHaaShDB.spActivateRegisteredUser,
                    new SqlParameter() { ParameterName = "@Mobile", Value = mobile },
                    new SqlParameter() { ParameterName = "@Password", Value = password },
                    new SqlParameter() { ParameterName = "@Email", Value = email },
                    new SqlParameter() { ParameterName = "@Otp", Value = otp });

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return (int)reader[0];
                    }
                }
            }
            return -1;
        }

        public void SaveOtpInDatabase(string mobile, string email, string otp)
        {
            using (SqlConnection con = Connection.SqlConnectionObject)
            {
                SqlDataReader reader = ExecuteVHaaShDB.ExecuteReader(con, VHaaShDB.spSaveOtpInDatabase,
                    new SqlParameter() { ParameterName = "@Mobile", Value = mobile },
                    new SqlParameter() { ParameterName = "@Email", Value = email },
                    new SqlParameter() { ParameterName = "@Otp", Value = otp });
            }
        }

        public string GetOtpFromDatabase(string mobile, string email)
        {
            using (SqlConnection con = Connection.SqlConnectionObject)
            {
                SqlParameter otp = new SqlParameter() { ParameterName = "@Otp", DbType = DbType.String, Size = 6, Direction = ParameterDirection.Output };
                SqlDataReader reader = ExecuteVHaaShDB.ExecuteReader(con, VHaaShDB.spGetOtpFromDatabase,
                    new SqlParameter() { ParameterName = "@Mobile", Value = mobile },
                    new SqlParameter() { ParameterName = "@Email", Value = email }, otp);
                return otp.Value.ToString();
            }

            return string.Empty;
        }

        public User Authenticate(string username, string password)
        {
            User user = new User();

            using (SqlConnection con = Connection.SqlConnectionObject)
            {
                SqlDataReader reader = ExecuteVHaaShDB.ExecuteReader(con, VHaaShDB.spAuthenticateUser,
                     new SqlParameter() { ParameterName = "@UserName", Value = username },
                     new SqlParameter() { ParameterName = "@Password", Value = password });


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.AccountLocked = (int)reader["AccountLocked"];
                        user.IsAuthenticated = (int)reader["Authenticated"];
                        user.RetryAttempts = (int)reader["RetryAttempts"];
                    }
                }
            }

            return user;
        }

        public int ChangePasswordOnFirstLogin(string userName, string currentPassword, string newPassword)
        {
            using (SqlConnection con = Connection.SqlConnectionObject)
            {
                SqlDataReader reader = ExecuteVHaaShDB.ExecuteReader(con, VHaaShDB.spChangePasswordOnFirstLogin,
                     new SqlParameter() { ParameterName = "@Username", Value = userName },
                     new SqlParameter() { ParameterName = "@CurrentPassword", Value = currentPassword },
                     new SqlParameter() { ParameterName = "@NewPassword", Value = newPassword });

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return (int)reader[0];
                    }
                }
            }

            return -1;
        }
    }
}
