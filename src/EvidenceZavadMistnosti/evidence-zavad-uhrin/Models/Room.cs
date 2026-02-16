using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace evidence_zavad_uhrin.Models
{
    [Table("Rooms")]
    public class Room
    {
        [Key]
        [Column("Id")]
        public int RoomId { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Floor")]
        public int Floor { get; set; }

        [Column("Description")]
        public string RoomDescription { get; set; } = string.Empty;
    }
}