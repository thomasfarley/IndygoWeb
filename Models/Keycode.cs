using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndygoWeb.Models
{
    public class Keycode
    {
        [Key]
        [MaxLength(30)]
        public string KeycodeId { get; set; }
        
        [ForeignKey("Token")]
        public string TokenId { get; set; }
        public Token Token { get; set; }
        
        [DefaultValue(0)]
        public int MaxRegistrations { get; set; }
        
        [DefaultValue(0)]
        public int ExpirationLength { get; set; }
        
        [DefaultValue(0)]
        public byte Package { get; set; }
        
        [DefaultValue(0)]
        public bool IsBanned { get; set; }
    }
}