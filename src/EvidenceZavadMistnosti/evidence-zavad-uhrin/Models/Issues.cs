using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace evidence_zavad_uhrin.Models
{
    [Table("Issues")]
    public class Issues
    {
        [Key]
        [Column("Id")]
        public int IssuesId { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("Description")]
        public string IssueDescription { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        [Column("RoomId")]
        public int RoomId { get; set; }
    }
}
