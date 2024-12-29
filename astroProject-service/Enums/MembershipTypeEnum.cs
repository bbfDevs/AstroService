using System.ComponentModel;

namespace astroProject_service.Entities.UserModels
{
    public enum MembershipTypeEnum
    {
        [Description("Free")]
        Free = 1,

        [Description("Premium")]
        Premium = 2,
    }
}
