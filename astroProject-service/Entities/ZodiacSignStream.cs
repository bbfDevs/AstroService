using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace astroProject_service.Entities
{
    public class ZodiacSignStream : RecordInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "VARCHAR(250)")]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(250)")]
        public string Period { get; set; }

        [Column(TypeName = "VARCHAR(2500)")]
        public string Description { get; set; }

        [Column(TypeName = "VARCHAR(250)")]
        public string Catagory { get; set; }

        public DateTime Date { get; set; }
    }
}
