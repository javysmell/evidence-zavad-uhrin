using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evidence_zavad_uhrin.Entities
{
    public class User
    {
        [Key]
        [Column("Id")]
        public int UserId { get; set; }

        [Required]
        [Column("Username")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [Column("Password")]
        public string Password { get; set; } = string.Empty;
    }
}

