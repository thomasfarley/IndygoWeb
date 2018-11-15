using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndygoWeb.Models
{
    public class UserCompany
    {
        [Key]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        [ForeignKey("User")]
        public string Username { get; set; }
        public User User { get; set; }

        [Required]
        [DefaultValue(0)]
        public byte UserAccessLevel { get; set; }

        [MaxLength(40)]
        public string UserTitle { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool IsActiveUser { get; set; }
    }
}