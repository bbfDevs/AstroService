using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace astroProject_service.Entities
{
    public class RecordInfo
    {
        public Guid CreatedBy { get; set; }

        public Guid ProcessId { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
