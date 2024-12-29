using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace astroProject_service.Entities.EnumModels
{
    public class EnumEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(250)")]
        public string Description { get; set; } = null!;
    }
}
