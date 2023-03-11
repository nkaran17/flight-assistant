namespace FlightAssistant.Core.Models.Queries
{
    public class Query
    {
        public int Page { get; protected set; } = 1;
        public int ItemsPerPage { get; protected set; } = 10;
    }
}
