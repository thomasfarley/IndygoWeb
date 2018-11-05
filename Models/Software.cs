using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndygoWeb.Models
{
    public class Software
    {
        [Key]
        [ForeignKey("Token")]
        public string TokenId { get; set; } 
        public Token Token { get; set; }
        
        [MaxLength(50)]
        public string SoftwareName { private get; set; }

        [MaxLength(25)]
        [DefaultValue("1.0")]
        public string LatestVersion { get; set; }

        [DefaultValue(false)]
        public bool UseAutomaticUpdates { get; set; }
    }
}