using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndygoWeb.Models
{
    public class KeycodeBan
    {
        [Key]
        [ForeignKey("Keycode")]
        public string KeycodeId { get; set; }
        public Keycode Keycode { get; set; }
        
        [Required]
        [ForeignKey("Token")]
        public string TokenId { get; set; }
        public Token Token { get; set; }

        public DateTime BanDate { get; set; }
        
        [Required]
        [DefaultValue("Terms of Service violation.")]
        public string BanReason { get; set; }
    }
}