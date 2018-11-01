using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndygoWeb.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        [MaxLength(20)]
        public string CompanyPhone { get; set; }

        [MaxLength(40)]
        public string CompanyWebsite { get; set; }

        [MaxLength(40)]
        public string CompanyStreetAddress { get; set; }

        [MaxLength(25)]
        public string CompanyCity { get; set; }

        [MaxLength(45)]
        public string CompanyCountry { get; set; }
    }
}