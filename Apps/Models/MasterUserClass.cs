using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Ajax.Utilities;

namespace Apps.Models
{
    public class MasterUserClass
    {
        private SqlConnection connection = null;
        public MasterUserClass()
        {
            
        }

        public List<MasterUser> GetData(string ConnectionString, string Email, String PasswordHash)
        {

            SqlCommand command = null;

            DataTable dt = null;

            SqlDataAdapter da = null;

            List<MasterUser> list = null;

            MasterUser user = null;

            string commandText = string.Empty;


            DateTime passwordResetTokenExpires;
            DateTime tokenCreated;
            DateTime tokenExpires;
            DateTime createdDateTime;
            DateTime editedDateTime;
            


            try
            {
                connection = new SqlConnection(ConnectionString);

                connection.Open();

                list = new List<MasterUser>();

                user = new MasterUser();

                da = new SqlDataAdapter();
                
                dt = new DataTable();

                commandText = "MasterUserGetLoginData";

                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = commandText;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("Email", Email);
                //command.Parameters.AddWithValue("PasswordHash", PasswordHash);

                da.SelectCommand = command;
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    user.ID = Convert.ToInt32(row["ID"].ToString());
                    user.Name = row["Name"].ToString();
                    user.Account = row["Account"].ToString();
                    user.Email = row["Email"].ToString();
                    user.PasswordHash = row["PasswordHash"].ToString();
                    user.PasswordSalt = row["PasswordSalt"].ToString();
                    user.PasswordResetToken = row["PasswordResetToken"].ToString();
                    DateTime.TryParse(row["PasswordResetTokenExpires"].ToString(), out passwordResetTokenExpires);
                    user.PasswordResetTokenExpires = passwordResetTokenExpires;
                    user.RefreshToken = row["RefreshToken"].ToString();
                    DateTime.TryParse(row["TokenCreated"].ToString(), out tokenCreated);
                    user.TokenCreated = tokenCreated;
                    DateTime.TryParse(row["TokenExpires"].ToString(), out tokenExpires);
                    user.TokenExpires = tokenExpires;
                    user.JobLevelID = row["JobLevelID"].ToString();
                    user.JobLevel = row["JobLevel"].ToString();
                    user.CreatedBy = row["CreatedBy"].ToString();
                    DateTime.TryParse(row["CreatedDateTime"].ToString(), out createdDateTime);
                    user.CreatedDateTime = createdDateTime;
                    user.EditedBy = row["EditedBy"].ToString();
                    DateTime.TryParse(row["EditedDateTime"].ToString(), out editedDateTime);
                    user.EditedDateTime = editedDateTime;
                    user.IsEnable = Convert.ToByte(row["IsEnable"].ToString());

                    list.Add(user);
                }

                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                da.Dispose();
                command.Dispose();
                connection.Dispose();
            }

        }

    }
}