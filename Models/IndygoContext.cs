using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IndygoWeb.Models
{
    public class IndygoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public IndygoContext() : base("name=IndygoContext")
        {
        }

        public DbSet<Token> Tokens { get; set; }

        public System.Data.Entity.DbSet<IndygoWeb.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<IndygoWeb.Models.Keycode> Keycodes { get; set; }

        public System.Data.Entity.DbSet<IndygoWeb.Models.KeycodeBan> KeycodeBans { get; set; }

        public System.Data.Entity.DbSet<IndygoWeb.Models.KeyRegistration> KeyRegistrations { get; set; }

        public System.Data.Entity.DbSet<IndygoWeb.Models.Software> Softwares { get; set; }

        public System.Data.Entity.DbSet<IndygoWeb.Models.SoftwareBan> SoftwareBans { get; set; }

        public System.Data.Entity.DbSet<IndygoWeb.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<IndygoWeb.Models.UserCompany> UserCompanies { get; set; }
    }
}
