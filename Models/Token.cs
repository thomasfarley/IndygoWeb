using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IndygoWeb.Models
{
    public class Token
    { 
        [Key]
        public string TokenId { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        public DateTime TimeCreated
        {
            get
            {
                return timeCreated ?? DateTime.Now;
            }
            set
            {
                timeCreated = value;
            }
        }
        private DateTime? timeCreated = null;

        [Required]
        [DefaultValue(false)]
        public bool IsDisabled { get; set; }
    }
}