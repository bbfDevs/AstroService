using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using astroProject_service.Enums;

namespace astroProject_service.Entities.UserModels
{
    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string? Name { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string? Surname { get; set; }

        [Column(TypeName = "VARCHAR(250)")]
        public string? Occupation { get; set; }

        public RelationshipTypeEnum? RelationshipType { get; set; }

        public DateTime? BirthDate { get; set; }

        public ZodiacEnum? Zodiac { get; set; }

        public string? ZodiacDescription => Zodiac?.ToDescription();

        public string? RelationshipTypeDescription => RelationshipType?.ToDescription();

        [JsonIgnore]
        public User? User { get; set; }

    }
}
