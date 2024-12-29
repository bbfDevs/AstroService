using System.ComponentModel;

namespace astroProject_service.Entities.UserModels
{
    public enum RelationshipTypeEnum
    {
        [Description("Single")]
        Single = 1,

        [Description("Married")]
        Married = 2,

        [Description("Widow")]
        Widow = 3,

        [Description("In a relationship")]
        InRelationship = 4,

        [Description("Divorced")]
        Divorced = 5,

        [Description("Engaged")]
        Engaged = 6,
    }
}
