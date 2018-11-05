using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndygoWeb.Models
{
    public class KeyRegistration
    {
        [Key]
        [ForeignKey("Keycode")]
        public string KeycodeId { get; set; }
        public Keycode Keycode { get; set; }
        
        [ForeignKey("Token")]
        public string TokenId { get; set; }
        public Token Token { get; set; }
        
        public DateTime RegistrationDate
        {
            get
            {
                return registrationDate ?? DateTime.Now;
            }
            set
            {
                registrationDate = value;
            }
        }
        private DateTime? registrationDate = null;

        public DateTime ExpirationDate { get; set; }

        [DefaultValue("0.0.0.0")]
        public string IPAddress { get; set; }
    }
}