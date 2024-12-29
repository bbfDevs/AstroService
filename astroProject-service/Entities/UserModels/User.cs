using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace astroProject_service.Entities.UserModels
{
    public class User : RecordInfo
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "VARCHAR(250)")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(256)")]
        public string? Password { get; set; }

        [Column(TypeName = "VARCHAR(12)")]
        public string PhoneNumber { get; set; } = null!;

        public MembershipTypeEnum MembershipType { get; set; }

        public string MembershipTypeDescription => MembershipType.ToDescription();

        public List<Profile>? Profiles { get; set; }
    }
}
