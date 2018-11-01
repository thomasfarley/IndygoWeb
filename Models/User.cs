using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IndygoWeb.Models
{
    public class User
    {
        [Key]
        [MaxLength(25)]
        public string Username { get; set; }

        [MaxLength(75)]
        [Required]
        [DefaultValue("Test")]
        public string Password { get; private set; }//ToDo hashing

        [Required]
        [MaxLength(75)]
        public string Email { get; set; }

        [Required]
        public DateTime DateRegistered
        {
            get
            {
                return dateRegistered ?? DateTime.Now;
            }
            set
            {
                this.dateRegistered = value;
            }
        }
        private DateTime? dateRegistered = null;
    }
}