using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evidence_zavad_uhrin.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [Column("Id")]
        public int UserId { get; set; }

        [Column("Username")]
        public string Username { get; set; }

        [Column("Password")]
        public string Password { get; set; }
    }
}
