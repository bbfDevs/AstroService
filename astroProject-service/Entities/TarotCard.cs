using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace astroProject_service.Entities
{
    public class TarotCard : RecordInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "VARCHAR(250)")]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(250)")]
        public string Type { get; set; }
    }
}
