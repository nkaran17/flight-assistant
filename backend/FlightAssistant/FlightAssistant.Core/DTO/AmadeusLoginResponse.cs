namespace FlightAssistant.Core.DTO
{
    public class AmadeusLoginResponse
    {
        public string type { get; set; } = null!;
        public string username { get; set; } = null!;
        public string application_name { get; set; } = null!;
        public string client_id { get; set; } = null!;
        public string token_type { get; set; } = null!;
        public string access_token { get; set; } = null!;
        public int expires_in { get; set; }
        public string state { get; set; } = null!;
    }
}
