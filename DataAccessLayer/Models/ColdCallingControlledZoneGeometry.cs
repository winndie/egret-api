using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgretApi.DataAccessLayer.Models
{
    [Table("ColdCallingControlledZoneGeometry")]
    public class ColdCallingControlledZoneGeometry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ColdCallingControlledZoneID { get; set; }

        [Required]
        public int GeometryType { get; set; }

        [Required]
        public string Coordinates { get; set; }
    }
}
