using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndygoWeb.Models
{
    public class SoftwareBan
    {
        [Key]
        [ForeignKey("Token")]
        public string TokenId { get; set; }
        public Token Token { get; set; }

        [MaxLength(45)]
        [DefaultValue("Terms of Service violation.")]
        public string BanReason { get; set; }
        
        public DateTime BanDate
        {   get
            {
                return banDate ?? DateTime.Now;
            }
            set
            {
                this.banDate = value;
            }
        }
        private DateTime? banDate = null;
    }
}