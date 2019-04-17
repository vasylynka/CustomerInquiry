using System.ComponentModel;

namespace CustomerInquiry.Entities.Types
{
    public enum Status
    {
        [Description("Success")]
        Success = 1,

        [Description("Failed")]
        Failed,

        [Description("Canceled")]
        Canceled
    }
}
