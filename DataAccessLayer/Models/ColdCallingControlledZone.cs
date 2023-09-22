using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgretApi.DataAccessLayer.Models
{
    [Table("ColdCallingControlledZone")]
    public class ColdCallingControlledZone
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ObjectId { get; set; }

        [Required]
        [StringLength(100)]
        public string Zones { get; set; }

        [Required]
        [StringLength(100)]
        public string Ward { get; set; }

        public virtual ColdCallingControlledZoneGeometry Geometry { get; set; }

    }
}
