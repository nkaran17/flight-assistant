namespace FlightAssistant.Core.Helpers
{
    public static class DateTimeHelper
    {
        public static string DateOnly(DateTime? datetime)
        {
            if (datetime != null)
            {
                return datetime.Value.ToString("yyyy-MM-dd");
            }
            return null;
        }
    }
}
