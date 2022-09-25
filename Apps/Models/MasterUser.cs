using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apps.Models
{
    public class MasterUser
    {
        public int ID { get; set; }
		public string Name { get; set; }	
		public string Account { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string PasswordSalt { get; set; }
		public string PasswordResetToken { get; set; }
		public DateTime PasswordResetTokenExpires { get; set; }
		public string RefreshToken { get; set; }
		public DateTime TokenCreated { get; set; }
		public DateTime TokenExpires { get; set; }
		public string JobLevelID { get; set; }
		public string JobLevel { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedDateTime { get; set; }
		public string EditedBy { get; set; }
		public DateTime EditedDateTime { get; set; }
		public byte IsEnable { get; set; }

    
    }
}