using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace evidence_zavad_uhrin.Models
{
    [Table("Rooms")]
    public class Rooms
    {
        [Key]
        [Column("Id")]
        public int RoomsId { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Floor")]
        public int Floor { get; set; }

        [Column("Description")]
        public string RoomDescription { get; set; }

        [Column("ResponsibleUserId")]
        public string ResponsibleUserId { get; set; }
    }
}
