using Apps.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apps
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LogIn(object sender, EventArgs e)
        {
            HashPasswordClass hash = null;
            
            MasterUserClass user = null;

            List<MasterUser> list = null;

            string connectionString = string.Empty;

            string email = string.Empty;

            byte[] passwordHash;

            byte[] passwordSalt;

            string password = string.Empty;

            bool loginVerified = false;
            

            try
            {

                

                hash = new HashPasswordClass();

                user = new MasterUserClass();

                list = new List<MasterUser>();

                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                email = Email.Text;

                hash.CreatePasswordHash(Password.Text, out passwordHash, out passwordSalt);


                //hash.VerifyPasswordHash(Password.Text, passwordHash, passwordSalt);

                password = Convert.ToBase64String(passwordHash);

                password = Convert.ToBase64String(passwordSalt);

                list = user.GetData(connectionString, email, password);

                foreach (MasterUser usr in list)
                {
                    byte[] pSalt = Convert.FromBase64String(usr.PasswordSalt);

                    byte[] pHash = Convert.FromBase64String(usr.PasswordHash);

                    loginVerified = hash.VerifyPasswordHash(Password.Text, pHash, pSalt);

                    // SET SESSION DI SINI
                    // ...
                    // SET SESSION DI SINI

                }
                if (loginVerified)
                {
                    
                    Response.Redirect("About.aspx", true);
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }
    }
}