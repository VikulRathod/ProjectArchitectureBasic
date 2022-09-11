using System;
using System.Data;
using System.Data.SqlClient;
using VHaaSh.DataAccessLayer.Interfaces.Account;
using VHaaSh.Models.Account;

namespace VHaaSh.DataAccessLayer.DatabaseLogic.Account
{
    public class AuthorizationDB : IAuthorizationDB
    {
        public ResetPasswordRequest ResetPasswordRequest(string userName)
        {
            ResetPasswordRequest resetPassword = new ResetPasswordRequest() { Username = userName };

            using (SqlConnection con = new SqlConnection(DBConstants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(DBConstants.spResetPassword, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", userName);

                SqlParameter returnCode = new SqlParameter()
                {
                    ParameterName = "@ReturnCode",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                SqlParameter uniqueId = new SqlParameter()
                {
                    ParameterName = "@UniqueId",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Direction = ParameterDirection.Output
                };

                SqlParameter email = new SqlParameter()
                {
                    ParameterName = "@Email",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(returnCode);
                cmd.Parameters.Add(uniqueId);
                cmd.Parameters.Add(email);

                con.Open();
                cmd.ExecuteNonQuery();

                if ((int)returnCode.Value == 1)
                {
                    resetPassword.Email = email.Value.ToString();
                    resetPassword.UserGuid = (Guid)uniqueId.Value;
                }
            }

            return resetPassword;
        }

        public bool IsPasswordResetLinkValid(Guid userGuid)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(DBConstants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(DBConstants.spIsPasswordResetLinkValid, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@GUID", userGuid);

                SqlParameter isValidPasswordResetLink = new SqlParameter()
                {
                    ParameterName = "@IsValidPasswordResetLink",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(isValidPasswordResetLink);

                con.Open();
                cmd.ExecuteNonQuery();

                result = (bool)isValidPasswordResetLink.Value;
            }
            return result;
        }

        public bool ChangePassword(Guid userGuid, string password)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(DBConstants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(DBConstants.spChangePassword, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@GUID", userGuid);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlParameter isPasswordChanged = new SqlParameter()
                {
                    ParameterName = "@IsPasswordChanged",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(isPasswordChanged);

                con.Open();
                cmd.ExecuteNonQuery();

                result = (bool)isPasswordChanged.Value;
            }
            return result;
        }

        public bool ChangePasswordUsingCurrentPassword(string userName, string password, string newPassword)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(DBConstants.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(DBConstants.spChangePasswordUsingCurrentPassword, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@CurrentPassword", password);
                cmd.Parameters.AddWithValue("@NewPassword", newPassword);

                SqlParameter isPasswordChanged = new SqlParameter()
                {
                    ParameterName = "@IsPasswordChanged",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(isPasswordChanged);

                con.Open();
                cmd.ExecuteNonQuery();

                result = (bool)isPasswordChanged.Value;
            }
            return result;
        }
    }
}