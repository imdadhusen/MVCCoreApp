using System.Data;

namespace SampleMvcCoreApp.Helper
{
    public static class DateHelper
    {
        public static DateTime GetUTC { get { return DateTime.UtcNow; } }
    }
}
